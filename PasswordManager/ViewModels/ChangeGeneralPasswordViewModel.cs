using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using System.Windows.Input;

namespace PasswordManager.ViewModels
{
    public class ChangeGeneralPasswordViewModel : BaseViewModel
    {
        private string newPassword;
        public string NewPassword { get => newPassword; set { newPassword = value; OnPropertyChanged(); } }

        public ICommand ChangeGeneralPassword { get; set; }

        public ChangeGeneralPasswordViewModel()
        {
            SetupCommands();
        }

        public void SetupCommands()
        {
            ChangeGeneralPassword = new RelayCommand(() => DI.Provider.GetService<GeneralPasswordController>().ChangeGeneralPassword());
        }
    }
}
