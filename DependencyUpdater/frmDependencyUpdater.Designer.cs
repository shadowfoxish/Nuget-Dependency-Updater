namespace DependencyUpdater
{
	partial class frmDependencyUpdater
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDependencyUpdater));
			this.gbTarget = new System.Windows.Forms.GroupBox();
			this.gbSource = new System.Windows.Forms.GroupBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.cmdCopy = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.miTestMode = new System.Windows.Forms.ToolStripMenuItem();
			this.miConfirmOverwrites = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditConfig = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// gbTarget
			// 
			this.gbTarget.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbTarget.Location = new System.Drawing.Point(406, 3);
			this.gbTarget.Name = "gbTarget";
			this.gbTarget.Size = new System.Drawing.Size(248, 322);
			this.gbTarget.TabIndex = 5;
			this.gbTarget.TabStop = false;
			this.gbTarget.Text = "Project to update?";
			// 
			// gbSource
			// 
			this.gbSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbSource.Location = new System.Drawing.Point(3, 3);
			this.gbSource.Name = "gbSource";
			this.gbSource.Size = new System.Drawing.Size(247, 322);
			this.gbSource.TabIndex = 6;
			this.gbSource.TabStop = false;
			this.gbSource.Text = "What component?";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.tsslStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 328);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(657, 22);
			this.statusStrip1.TabIndex = 8;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslStatus
			// 
			this.tsslStatus.Name = "tsslStatus";
			this.tsslStatus.Size = new System.Drawing.Size(26, 17);
			this.tsslStatus.Text = "Idle";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.gbSource, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.gbTarget, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(657, 328);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.cmdCopy, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(256, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(144, 322);
			this.tableLayoutPanel2.TabIndex = 7;
			// 
			// cmdCopy
			// 
			this.cmdCopy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdCopy.Location = new System.Drawing.Point(34, 270);
			this.cmdCopy.Name = "cmdCopy";
			this.cmdCopy.Size = new System.Drawing.Size(75, 49);
			this.cmdCopy.TabIndex = 11;
			this.cmdCopy.Text = "Copy";
			this.cmdCopy.UseVisualStyleBackColor = true;
			this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pictureBox1.Image = global::DependencyUpdater.Properties.Resources.arrow_right;
			this.pictureBox1.Location = new System.Drawing.Point(18, 65);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(107, 91);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miTestMode,
            this.miConfirmOverwrites,
            this.miEditConfig,
            this.toolStripMenuItem2,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.toolStripDropDownButton1.Image = global::DependencyUpdater.Properties.Resources.configure_2;
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
			// 
			// miTestMode
			// 
			this.miTestMode.CheckOnClick = true;
			this.miTestMode.Name = "miTestMode";
			this.miTestMode.Size = new System.Drawing.Size(225, 22);
			this.miTestMode.Text = "Test Mode (no copies made)";
			this.miTestMode.Click += new System.EventHandler(this.miTestMode_Click);
			// 
			// miConfirmOverwrites
			// 
			this.miConfirmOverwrites.CheckOnClick = true;
			this.miConfirmOverwrites.Name = "miConfirmOverwrites";
			this.miConfirmOverwrites.Size = new System.Drawing.Size(225, 22);
			this.miConfirmOverwrites.Text = "Confirm Overwrites";
			this.miConfirmOverwrites.Click += new System.EventHandler(this.miConfirmOverwrites_Click);
			// 
			// miEditConfig
			// 
			this.miEditConfig.Image = global::DependencyUpdater.Properties.Resources.configure_2;
			this.miEditConfig.Name = "miEditConfig";
			this.miEditConfig.Size = new System.Drawing.Size(225, 22);
			this.miEditConfig.Text = "Edit Configuration...";
			this.miEditConfig.Click += new System.EventHandler(this.miEditConfig_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(222, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = global::DependencyUpdater.Properties.Resources.help_about_3;
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Image = global::DependencyUpdater.Properties.Resources.help_contents_5;
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.helpToolStripMenuItem.Text = "Help...";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// frmDependencyUpdater
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(657, 350);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(673, 388);
			this.Name = "frmDependencyUpdater";
			this.Text = "Nuget Dependency Updater";
			this.Load += new System.EventHandler(this.frmDependencyUpdater_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox gbTarget;
		private System.Windows.Forms.GroupBox gbSource;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem miTestMode;
		private System.Windows.Forms.ToolStripMenuItem miConfirmOverwrites;
		private System.Windows.Forms.Button cmdCopy;
		private System.Windows.Forms.ToolStripMenuItem miEditConfig;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	}
}

