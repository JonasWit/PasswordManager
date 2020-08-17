using PasswordManager.DI;
using PasswordManager.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Config;

namespace PasswordManager.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {
        private string title;
        public string Title { get { return title; } set { title = value; OnPropertyChanged(); } }

        private bool licenseValid;
        public bool LicenseValid { get { return licenseValid; } set { licenseValid = value; OnPropertyChanged(); } }

        private AppPage currentPage;
        public AppPage CurrentPage { get { return currentPage; } set { currentPage = value; OnPropertyChanged(); } }

        #region Commands


        #endregion

        public WindowViewModel()
        {
            try
            {
                var licenseManagger = DIProvider.Provider.GetService<LicenseHandler>();

                if (licenseManagger.CheckLicense())
                {
                    LicenseValid = true;
                    CurrentPage = AppPage.Welcome;
                }
                else
                {
                    LicenseValid = false;
                    CurrentPage = AppPage.Welcome;
                }
               
                SetUpCommands();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetUpCommands()
        {

        }

    }
}
