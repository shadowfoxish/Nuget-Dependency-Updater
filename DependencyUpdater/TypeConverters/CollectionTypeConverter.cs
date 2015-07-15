using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyUpdater.TypeConverters
{
	public class CollectionTypeConverter<T> : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				var list = value as ICollection<T>;
				if (list != null && list.Count > 0)
				{
					return string.Format("[{0}] Items", list.Count);
				}
				else
				{
					return "Click to edit";
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
