using PasswordManager.Dependancies;
using PasswordManager.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Config;
using PasswordManager.Data;
using System.Windows.Input;
using PasswordManager.Controllers;

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

        public ICommand Exit { get; set; }

        #endregion

        public WindowViewModel()
        {
            try
            {
                var licenseManagger = DI.Provider.GetService<LicenseHandler>();
                var filesHandler = DI.Provider.GetService<FilesHandler>();

                if (licenseManagger.CheckLicense())
                {
                    LicenseValid = true;
                    CurrentPage = AppPage.Welcome;
                }
                else
                {
                    LicenseValid = false;
                    CurrentPage = AppPage.License;
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
            Exit = new RelayCommand(() => DI.Provider.GetService<WindowController>().Exit());
        }

    }
}
