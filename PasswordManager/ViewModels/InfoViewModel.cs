using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager.ViewModels
{
    public class InfoViewModel : BaseViewModel
    {
        private string infoTitle;
        public string InfoTitle { get => infoTitle; set { infoTitle = value; OnPropertyChanged(); } }

        private string infoMessage;
        public string InfoMessage { get => infoMessage; set { infoMessage = value; OnPropertyChanged(); } }

        public ICommand Dismiss { get; set; }

        public InfoViewModel()
        {
            SetupCommands();
        }

        public void SetupCommands()
        {
            Dismiss = new RelayCommand(() => DI.Provider.GetService<InfoController>().Dismiss());
        }
    }
}
