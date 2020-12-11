using DataModels;
using Pages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Converters
{
    /// <summary>
    /// Ковертер для переключения страниц
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Main:
                    return new MainPage();                
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if(value is MainPage) return ApplicationPage.Main;
            //if(value is AddDepartmentPage) return ApplicationPage.AddDepartment;
            
            return null;
        }
    }
}
