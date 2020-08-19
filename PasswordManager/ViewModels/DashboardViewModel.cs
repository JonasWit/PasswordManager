using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Infrastructure;
using System.Runtime.InteropServices;

namespace PasswordManager.ViewModels
{
    class DashboardViewModel : BaseViewModel
    {
        private ObservableCollection<PasswordRecord> passwords;
        public ObservableCollection<PasswordRecord> Passwords { get => passwords; set { passwords = value; OnPropertyChanged(); } }

        private PasswordRecord selectedPassword;
        public PasswordRecord SelectedPassword { get => selectedPassword; set { selectedPassword = value; OnPropertyChanged(); } }

        public ICommand GetPassword { get; set; }

        public DashboardViewModel()
        {
            SetupCommands();
            SetupControls();
        }

        public void SetupControls()
        {
            var repo = DI.Provider.GetService<IAppRepository>();
            Passwords = new ObservableCollection<PasswordRecord>(repo.GetPasswords());
        }

        public void SetupCommands()
        {
            GetPassword = new RelayCommand(() => Dependancies.DI.Provider.GetService<DashboardController>().GetPassword());
        }
    }
}
