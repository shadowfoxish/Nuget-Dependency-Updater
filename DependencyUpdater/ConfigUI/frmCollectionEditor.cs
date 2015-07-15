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
	public partial class frmCollectionEditor : Form
	{
		public BindingList<DepConfigItem> InitialItems { get; set; }

		public frmCollectionEditor()
		{
			InitializeComponent();
			this.DialogResult = DialogResult.Cancel;
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void frmCollectionEditor_Load(object sender, EventArgs e)
		{
			lstItems.DataSource = this.InitialItems;
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdAdd_Click(object sender, EventArgs e)
		{
			this.InitialItems.Add(new DepConfigItem() { Name = "*New Config Item" });
		}

		private void cmdRemove_Click(object sender, EventArgs e)
		{
			if (lstItems.SelectedItem != null)
			{
				this.InitialItems.Remove(lstItems.SelectedItem as DepConfigItem);
			}
		}

		private void lstItems_SelectedValueChanged(object sender, EventArgs e)
		{
			pgEditor.SelectedObject = lstItems.SelectedItem;
		}

		private void cmdSave_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cmdCancel_Click_1(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
