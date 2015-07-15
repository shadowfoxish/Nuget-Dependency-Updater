using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DependencyUpdater.ConfigUI;

namespace DependencyUpdater
{
	public partial class frmDependencyUpdater : Form
	{
		private DepConfig config;

		public frmDependencyUpdater()
		{
			InitializeComponent();
		}

		private void cmdCopy_Click(object sender, EventArgs e)
		{
			try
			{
				RadioButton source = gbSource.Controls.OfType<RadioButton>().Where(item => item.Checked).FirstOrDefault();
				RadioButton target = gbTarget.Controls.OfType<RadioButton>().Where(item => item.Checked).FirstOrDefault();
				if (source != null && target != null)
				{
					DepConfigItem sourceCfg = source.Tag as DepConfigItem;
					DepConfigItem targetCfg = target.Tag as DepConfigItem;
					Copy(sourceCfg, targetCfg, miConfirmOverwrites.Checked, miTestMode.Checked);
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		private void HandleError(Exception ex)
		{
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			tsslStatus.Text = "Error";
		}

		private void Copy(DepConfigItem sourceCfg, DepConfigItem targetCfg, bool promptOverwrites, bool testMode)
		{
			//Find the source folder
			DirectoryInfo bin = new DirectoryInfo(sourceCfg.Path);
			if (bin.Exists == false)
			{
				throw new Exception("Configuration error: The bin directory for component " + sourceCfg.Name + " does not exist!");
			}

			DirectoryInfo packages = new DirectoryInfo(targetCfg.Path);
			if (packages.Exists == false)
			{
				throw new Exception("Configuration error: The packages directory for component " + targetCfg.Name + " does not exist!");
			}

			//Get files to copy from the bin
			List<FileInfo> filesToCopy = sourceCfg.FileGlobs.SelectMany(item => bin.GetFiles(item)).Distinct().ToList();

			//Determine the package path
			Regex regex = new Regex(sourceCfg.PackageExpression);
			List<DirectoryInfo> potentialPackageFolders = packages.GetDirectories().Where(item => regex.IsMatch(item.Name)).OrderByDescending(item => item.Name, new VersionAwareStringComparer()).ToList();

			if (!potentialPackageFolders.Any())
			{
				throw new Exception("Could not find a package folder matching pattern " + sourceCfg.PackageExpression);
			}

			//Determine the final path for files
			string finalPath = Path.Combine(potentialPackageFolders[0].FullName, sourceCfg.RelativePackagePathToBinaries);
			if (!Directory.Exists(finalPath))
			{
				throw new Exception("Could not find final path " + finalPath);
			}

			StringBuilder testModeOutput = new StringBuilder();

			//Copy the filesToCopy into the first potentialPackageFolders item (which would be the newest)
			foreach (FileInfo file in filesToCopy)
			{
				string targetPath = Path.Combine(finalPath, file.Name);
				if (testMode)
				{
					testModeOutput.AppendLine(string.Format("Copying {0} to {1}", file.FullName, targetPath));
				}
				else
				{
					if (File.Exists(targetPath) && promptOverwrites)
					{
						DialogResult confirmOverwrite = MessageBox.Show("Confirm file overwrite?\r\n" + targetPath + "\r\nWith: " + file.FullName, "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if (confirmOverwrite == DialogResult.Cancel)
						{
							tsslStatus.Text = "Cancelled";
							return;
						}
						else if (confirmOverwrite == DialogResult.No)
						{
							continue; //Move to next file
						}
					}
					file.CopyTo(targetPath, true);
				}
			}

			if (testMode)
			{
				MessageBox.Show(testModeOutput.ToString());
			}
			else
			{
				tsslStatus.Text = "Copied " + filesToCopy.Count + " files from " + sourceCfg.Name + " to " + targetCfg.Name;
			}
		}

		/// <summary>
		/// Gets the path the config file
		/// </summary>
		internal string GetConfigPath()
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"DependencyUpdater\config.xml");
		}

		private void SaveConfig()
		{
			this.config.ConfirmOverwrite = miConfirmOverwrites.Checked;
			this.config.TestMode = miTestMode.Checked;
			XmlSerializer cherios = new XmlSerializer(typeof(DepConfig));
			using (var fs = File.Open(GetConfigPath(), FileMode.Create))
			{
				cherios.Serialize(fs, this.config);
			}
			tsslStatus.Text = "Updated config!";
		}

		private void LoadConfig()
		{
			try
			{
				//Get config
				string path = GetConfigPath();
				DepConfig cfg = null;
				XmlSerializer cherios = new XmlSerializer(typeof(DepConfig));
				if (File.Exists(path))
				{
					using (var fs = File.OpenRead(path))
					{
						cfg = cherios.Deserialize(fs) as DepConfig;
					}
				}
				else if (!Directory.Exists(Path.GetDirectoryName(path)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(path));
				}

				if (cfg == null)
				{
					//Create default config
					cfg = new DepConfig();
					cfg.Items = new List<DepConfigItem>() {
						new DepConfigItem() {
							ContainerKind = DependencyUpdater.Container.Component,
							Name = "Shared Component 1",
							PackageExpression = @"^SharedComponent\.[0-9]+\.[0-9]+\.[0-9]+$",
							RelativePackagePathToBinaries = @"lib\net40-full",
							FileGlobs = new List<string>() {
								"*.dll",
								"*.xml",
								"*.pdb"
							},
							Path = @"C:\Code\A component\bin\Debug"
						},
						new DepConfigItem() {
							ContainerKind = DependencyUpdater.Container.Project,
							Name = "My Special Project",
							Path = @"C:\Code\MySpecialProject\packages"
						}
					};
					using (var fs = File.Open(GetConfigPath(), FileMode.Create))
					{
						cherios.Serialize(fs, cfg);
					}
				}
				this.config = cfg;
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		private void InitializeForm()
		{
			gbSource.Controls.Clear();
			gbTarget.Controls.Clear();

			int i = 0;
			foreach (DepConfigItem component in this.config.Items.Where(item => item.ContainerKind == DependencyUpdater.Container.Component))
			{
				gbSource.Controls.Add(new RadioButton()
				{
					Appearance = System.Windows.Forms.Appearance.Button,
					Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
					Location = new System.Drawing.Point(15, 24 + (i * 67)),
					Name = "radComponent" + i,
					Size = new System.Drawing.Size(gbSource.ClientSize.Width - 30, 61),
					TabIndex = 1,
					TabStop = true,
					Text = component.Name,
					UseVisualStyleBackColor = true,
					Tag = component,
					Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
					Checked = false
				});
				i++;
			}
			i = 0;
			foreach (DepConfigItem project in this.config.Items.Where(item => item.ContainerKind == DependencyUpdater.Container.Project))
			{
				gbTarget.Controls.Add(new RadioButton()
				{
					Appearance = System.Windows.Forms.Appearance.Button,
					Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
					Location = new System.Drawing.Point(15, 24 + (i * 67)),
					Name = "radProject" + i,
					Size = new System.Drawing.Size(gbTarget.ClientSize.Width - 30, 61),
					TabIndex = 1,
					TabStop = true,
					Text = project.Name,
					UseVisualStyleBackColor = true,
					Tag = project,
					Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
					Checked = false
				});
				i++;
			}

			miConfirmOverwrites.Checked = this.config.ConfirmOverwrite;
			miTestMode.Checked = this.config.TestMode;
		}

		private void frmDependencyUpdater_Load(object sender, EventArgs e)
		{
			LoadConfig();
			InitializeForm();
		}

		private void miTestMode_Click(object sender, EventArgs e)
		{
			SaveConfig();
		}

		private void miConfirmOverwrites_Click(object sender, EventArgs e)
		{
			SaveConfig();
		}

		private void miEditConfig_Click(object sender, EventArgs e)
		{
			frmEditConfigItems editor = new frmEditConfigItems();
			editor.Configuration = this.config.Copy();
			if (editor.ShowDialog() == DialogResult.OK)
			{
				this.config = editor.Configuration;
				this.SaveConfig();
				this.LoadConfig();
				this.InitializeForm();
			} 
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This will one day open a browser window to a sweet help page.");
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmAbout a = new frmAbout();
			a.ShowDialog();
		}
	}
}
