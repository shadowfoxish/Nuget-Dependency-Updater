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
	public enum Container {
		Component,
		Project
	};

	[Serializable]
	public class DepConfigItem
	{
		public DepConfigItem()
		{
			this.FileGlobs = new List<string>();
		}

		/// <summary>
		/// The kind of config item this is
		/// </summary>
		[Description("The kind of config item this is. Components copy files into Projects")]
		[Category("Common")]
		public Container ContainerKind { get; set; }

		/// <summary>
		/// The location of the packages folder for this project, or the bin directory for the component
		/// </summary>
		[Description("The location of the packages folder for this project, or, the bin directory for the component.")]
		[Category("Common")]
		[Editor(typeof(FolderBrowserUITypeEditor), typeof(UITypeEditor))]
		public string Path { get; set; }

		/// <summary>
		/// An expression that will match the Nuget package folder name
		/// </summary>
		[Description("The Regular expression to select the nuget package folder by name.")]
		[Category("Component Specific")]
		public string PackageExpression { get; set; }

		/// <summary>
		/// The relative path from the nuget package folder into which the files will be copied
		/// </summary>
		[Description("The relative path from the nuget package folder Path into which the files will be copied.")]
		[Category("Component Specific")]
		public string RelativePackagePathToBinaries { get; set; }

		/// <summary>
		/// Which files to update
		/// </summary>
		[Description("Specific files or wildcard patterns to select files to copy from a build directory.")]
		[Category("Component Specific")]
		[Editor(typeof(FileListUITypeEditor), typeof(UITypeEditor))]
		[TypeConverter(typeof(CollectionTypeConverter<string>))]
        public List<string> FileGlobs { get; set; }
		 
		/// <summary>
		/// The display name of this config item
		/// </summary>
		[Description("The display name for this Component or Project")]
		[Category("Common")]
		public string Name { get; set; }

		/// <summary>
		/// Deep copies this object to a new instance
		/// </summary>
		public DepConfigItem Copy()
		{
			DepConfigItem result = new DepConfigItem();
			result.ContainerKind = this.ContainerKind;
			result.Name = this.Name;
			result.PackageExpression = this.PackageExpression;
			result.Path = this.Path;
			result.RelativePackagePathToBinaries = this.RelativePackagePathToBinaries;
			if (this.FileGlobs != null)
			{
				result.FileGlobs = this.FileGlobs.Select(item => string.Copy(item)).ToList();
			}
			return result;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
