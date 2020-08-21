using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.Pages;
using System;
using System.Windows.Input;

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

        private string username;
        public string Username { get { return username; } set { username = value; OnPropertyChanged(); } }

        #region Commands

        public ICommand Exit { get; set; }
        public ICommand About { get; set; }

        #endregion

        public WindowViewModel()
        {
            try
            {
                Username = $" Hi! {Environment.UserName}";
                LicenseValid = true;
                CurrentPage = AppPage.Welcome;

                SetUpCommands();
            }
            catch (Exception)
            {
                DI.Provider.GetService<WindowController>().Exit();
            }
        }

        private void SetUpCommands()
        {
            Exit = new RelayCommand(() => DI.Provider.GetService<WindowController>().Exit());
            About = new RelayCommand(() => DI.Provider.GetService<WindowController>().About());
        }

    }
}
