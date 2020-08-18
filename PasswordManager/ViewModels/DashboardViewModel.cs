using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager.ViewModels
{
    class DashboardViewModel : BaseViewModel
    {
        private ObservableCollection<Password> passwords;
        public ObservableCollection<Password> Passwords { get => passwords; set { passwords = value; OnPropertyChanged(); } }

        private Password selectedPassword;
        public Password SelectedPassword { get => selectedPassword; set { selectedPassword = value; OnPropertyChanged(); } }

        public ICommand GetPassword { get; set; }

        public DashboardViewModel()
        {
            SetupCommands();


        }

        public void SetupCommands()
        {

            GetPassword = new RelayCommand(() => Dependancies.DI.Provider.GetService<DashboardController>().GetPassword());



        }
    }
}
