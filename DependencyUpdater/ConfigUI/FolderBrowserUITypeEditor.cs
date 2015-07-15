using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DependencyUpdater.ConfigUI
{
	public class FolderBrowserUITypeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (provider != null && value is string)
			{
				FolderBrowserDialog fbd = new FolderBrowserDialog();
				fbd.SelectedPath = value as string;
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					return fbd.SelectedPath;
				}
			}
			return value;
		}
	}
}
