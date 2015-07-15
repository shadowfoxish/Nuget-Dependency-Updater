namespace DependencyUpdater.ConfigUI
{
	partial class frmEditConfigItems
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
			this.pgConfig = new System.Windows.Forms.PropertyGrid();
			this.cmdSave = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pgConfig
			// 
			this.pgConfig.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.pgConfig.Location = new System.Drawing.Point(12, 12);
			this.pgConfig.Name = "pgConfig";
			this.pgConfig.Size = new System.Drawing.Size(422, 268);
			this.pgConfig.TabIndex = 2;
			this.pgConfig.ToolbarVisible = false;
			// 
			// cmdSave
			// 
			this.cmdSave.Location = new System.Drawing.Point(319, 286);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(107, 32);
			this.cmdSave.TabIndex = 3;
			this.cmdSave.Text = "Save";
			this.cmdSave.UseVisualStyleBackColor = true;
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(206, 286);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(107, 32);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmEditConfigItems
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(438, 330);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdSave);
			this.Controls.Add(this.pgConfig);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(454, 364);
			this.Name = "frmEditConfigItems";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Configurations";
			this.Load += new System.EventHandler(this.frmEditConfigItems_Load);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PropertyGrid pgConfig;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.Button cmdCancel;
	}
}