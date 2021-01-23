using System;
using System.Globalization;

namespace Converters
{
    public class ConverterStringToDouble : BaseValueConverter<ConverterStringToDouble>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value, culture);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value, culture);
        }
    }
}
