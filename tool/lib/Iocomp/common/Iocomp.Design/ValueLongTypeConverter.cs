using Iocomp.Classes;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Design
{
	public class ValueLongTypeConverter : ValueBaseConverter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				return new ValueLong(value as string);
			}
			return ConvertFrom(context, culture, value);
		}
	}
}
