using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;

namespace PasswordManager.ViewModels
{
    public class CreateViewModel : BaseViewModel
    {
        private string login;
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }

        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        private bool busy;
        public bool Busy { get => busy; set { busy = value; OnPropertyChanged(); } }

        public ICommand GeneratePassword { get; set; }

        public CreateViewModel()
        {
            SetUpCommands();
            Busy = false;
        }

        private void SetUpCommands()
        {
            GeneratePassword = new RelayCommand(async () => await DI.Provider.GetService<CreatePageController>().GeneratePassword());
        }
    }
}
