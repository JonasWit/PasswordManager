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
            return ((AppPage)value) switch
            {
                AppPage.Welcome => new Welcome(),
                AppPage.Dashboard => new Dashboard(),
                AppPage.Create => new Create(),
                AppPage.Delete => new Delete(),
                AppPage.Extract => new Extract(),
                AppPage.License => new License(),
                AppPage.ApplyLicenseKey => new ApplyLicenseKey(),
                AppPage.Loading => new Loading(),
                AppPage.Info => new Info(),
                _ => new Welcome(),
            };
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
