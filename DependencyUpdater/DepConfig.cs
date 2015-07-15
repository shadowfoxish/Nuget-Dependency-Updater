using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyUpdater.ConfigUI;
using DependencyUpdater.TypeConverters;

namespace DependencyUpdater
{
	[Serializable]
	public class DepConfig 
	{
		public DepConfig()
		{
			this.Items = new List<DepConfigItem>();
		}

		[Editor(typeof(DepConfigCollectionUITypeEditor), typeof(UITypeEditor))]
		[TypeConverter(typeof(CollectionTypeConverter<DepConfigItem>))]
        public List<DepConfigItem> Items { get; set; }

		[Description("When true, no files are actually copied and a summary of changes will be displayed instead.")]
        public bool TestMode { get; set; }

		[Description("When true, prompts you to confirm overwriting of copied files.")]
		public bool ConfirmOverwrite { get; set; }

		/// <summary>
		/// Performs a deep copy of the object and returns the new copy.
		/// </summary>
		public DepConfig Copy()
		{
			DepConfig result = new DepConfig();
			result.TestMode = this.TestMode;
			result.ConfirmOverwrite = this.ConfirmOverwrite;
			result.Items = this.Items.Select(item => item.Copy()).ToList();
			return result;
		}
	}
}
