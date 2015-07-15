using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace DependencyUpdater.ConfigUI
{
	public class DepConfigCollectionUITypeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (provider != null && value is List<DepConfigItem>)
			{
				frmCollectionEditor fce = new frmCollectionEditor();
				fce.InitialItems = new BindingList<DepConfigItem>((value as List<DepConfigItem>).Select(item => item.Copy()).ToList());
				if (fce.ShowDialog() == DialogResult.OK)
				{
					return fce.InitialItems.ToList();
				}
			}
			return value;
		}
	}
}
