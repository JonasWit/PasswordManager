using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.ViewModels;
using System.Windows.Controls;

namespace PasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();

            var vmc = DI.Provider.GetService<ViewModelsController>();
            DataContext = vmc.GetViewModel<WelcomeViewModel>();
        }
    }
}
