using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DependencyUpdater.ConfigUI
{
	public partial class frmFileListEditor : Form
	{
		public string InitialPath { get; set; }
		public List<string> InitialItems { get; set; }
		public List<string> SavedItems { get; set; }

		public frmFileListEditor()
		{
			InitializeComponent();
			this.DialogResult = DialogResult.Cancel;
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			this.SavedItems = GetItemsList();
			this.DialogResult = DialogResult.OK;
		}

		private List<string> GetItemsList()
		{
			return txtFilesAndPatterns.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
		}

		private void cmdBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Multiselect = true;
			ofd.InitialDirectory = this.InitialPath;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if (ofd.FileNames.Length > 0)
				{
					txtFilesAndPatterns.Text += (txtFilesAndPatterns.Text.Length > 0 ? Environment.NewLine : "") 
						+ string.Join(Environment.NewLine, ofd.FileNames.Select(file=>Path.GetFileName(file)));
				}
			}
		}

		private void frmFileListEditor_Load(object sender, EventArgs e)
		{
			txtFilesAndPatterns.Text = string.Join(Environment.NewLine, this.InitialItems);
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
