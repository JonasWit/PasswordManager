using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using System.Windows.Input;

namespace PasswordManager.ViewModels
{
    public class GetGeneralPasswordViewModel : BaseViewModel
    {
        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        public ICommand ApplyGeneralPassword { get; set; }

        public GetGeneralPasswordViewModel()
        {
            SetupCommands();
        }

        public void SetupCommands()
        {
            ApplyGeneralPassword = new RelayCommand(() => DI.Provider.GetService<GeneralPasswordController>().ApplyGeneralPassword());
        }
    }
}
