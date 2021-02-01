using Models;
using System;
using System.Globalization;

namespace Converters
{
    public class ConverterIntToStatusWorker : BaseValueConverter<ConverterIntToStatusWorker>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EmployeePosition number = (EmployeePosition)value;

            switch (number)
            {
                case EmployeePosition.Intern:
                    return 0;
                case EmployeePosition.Employee:
                    return 1;
                case EmployeePosition.Supervisor:
                    return 2;
                case EmployeePosition.GeneralDirector:
                    return 3;
                case EmployeePosition.ChiefAccountant:
                    return 4;
                case EmployeePosition.DeputyDirector:
                    return 5;
            }

            return EmployeePosition.Intern;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = System.Convert.ToInt32(value);

            switch (number)
            {
                case 0:
                    return EmployeePosition.Intern;
                case 1:
                    return EmployeePosition.Employee;
                case 2:
                    return EmployeePosition.Supervisor;
                case 3:
                    return EmployeePosition.GeneralDirector;
                case 4:
                    return EmployeePosition.ChiefAccountant;
                case 5:
                    return EmployeePosition.DeputyDirector;
            }

            return EmployeePosition.Intern;
        }
    }
}
