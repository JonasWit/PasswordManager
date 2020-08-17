using PasswordManager.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PasswordManager.Converters
{
    public class AppPageValueConverter : BaseValueConverter<AppPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((AppPage)value)
            {
                case AppPage.Welcome:
                    return new Welcome();
                case AppPage.Dashboard:
                    return new Welcome();
                case AppPage.Create:
                    return new Welcome();
                case AppPage.Delete:
                    return new Welcome();
                case AppPage.Extract:
                    return new Welcome();
                case AppPage.License:
                    return new Welcome();
                default:
                    return new Welcome();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
