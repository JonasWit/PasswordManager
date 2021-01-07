using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.ViewModels;
using System.Windows.Controls;

namespace PasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for GetGeneralPassword.xaml
    /// </summary>
    public partial class GetGeneralPassword : Page
    {
        public GetGeneralPassword()
        {
            InitializeComponent();

            var vmc = DI.Provider.GetService<ViewModelsController>();
            DataContext = vmc.GetViewModel<GetGeneralPasswordViewModel>();
        }
    }
}
