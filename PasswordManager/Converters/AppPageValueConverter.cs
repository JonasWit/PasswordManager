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
                    return new Dashboard();
                case AppPage.Create:
                    return new Create();
                case AppPage.Delete:
                    return new Delete();
                case AppPage.Extract:
                    return new Extract();
                case AppPage.License:
                    return new License();
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
