using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.ViewModels;

namespace PasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for ChangeGeneralPassword.xaml
    /// </summary>
    public partial class ChangeGeneralPassword : Page
    {
        public ChangeGeneralPassword()
        {
            InitializeComponent();

            var vmc = DI.Provider.GetService<ViewModelsController>();
            DataContext = vmc.GetViewModel<ChangeGeneralPasswordViewModel>();
        }
    }
}
