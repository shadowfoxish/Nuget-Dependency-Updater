using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace DependencyUpdater.ConfigUI
{
	public class FileListUITypeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (provider != null && value is List<string>)
			{
				DepConfigItem config = context.Instance as DepConfigItem;
				frmFileListEditor fle = new frmFileListEditor();
				fle.InitialPath = config.Path;
				fle.InitialItems = value as List<string>;

				if (fle.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					return fle.SavedItems;
				}
			}
			return value;
		}
	}
}
