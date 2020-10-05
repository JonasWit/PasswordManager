using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using System.Windows.Input;

namespace PasswordManager.ViewModels
{
    public class ExtractViewModel : BaseViewModel
    {
        public ICommand ExtractPassword { get; set; }

        public ExtractViewModel()
        {
            SetupCommands();
        }

        public void SetupCommands()
        {
            ExtractPassword = new RelayCommand(async () => await DI.Provider.GetService<ExtractController>().ExtractPasswords());
        }
    }
}
