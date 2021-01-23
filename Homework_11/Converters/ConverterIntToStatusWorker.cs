using Models;
using System;
using System.Globalization;

namespace Converters
{
    public class ConverterIntToStatusWorker : BaseValueConverter<ConverterIntToStatusWorker>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = System.Convert.ToInt32(value);

            switch(number)
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
