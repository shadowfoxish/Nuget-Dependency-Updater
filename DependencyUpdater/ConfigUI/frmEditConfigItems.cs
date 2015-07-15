using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DependencyUpdater.ConfigUI
{
	public partial class frmEditConfigItems : Form
	{
		public DepConfig Configuration { get; set; }

		public frmEditConfigItems()
		{
			InitializeComponent();
			this.DialogResult = DialogResult.Cancel;
		}

		private void cmdSave_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void frmEditConfigItems_Load(object sender, EventArgs e)
		{
			this.pgConfig.SelectedObject = this.Configuration;
		}
	}
}
