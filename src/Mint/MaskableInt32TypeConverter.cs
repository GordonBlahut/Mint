using System;
using System.ComponentModel;
using System.Globalization;

namespace Mint
{
    public class MaskableInt32TypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var valueAsString = value as string;
            if (valueAsString != null)
            {
                return MaskableInt32.GetUnmaskedValue(valueAsString);
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}