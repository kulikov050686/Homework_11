using Models;
using System;
using System.Globalization;

namespace Converters
{
    public class ConverterIntToStatusWorker : BaseValueConverter<ConverterIntToStatusWorker>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((EmployeePosition)value == EmployeePosition.Employee) return 1;
                        
            return 0;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(System.Convert.ToInt32(value) == 1) return EmployeePosition.Employee;
                        
            return EmployeePosition.Intern;
        }
    }
}
