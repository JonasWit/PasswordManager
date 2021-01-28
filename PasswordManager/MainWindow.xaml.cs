using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Config;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AppStartup.Initialize();
            InitializeComponent();

            var vmc = DI.Provider.GetService<ViewModelsController>();
            DataContext = vmc.GetViewModel<WindowViewModel>();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void SelectDashboardPage(object sender, MouseButtonEventArgs e) =>
            DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.Dashboard;

        private void SelectCreatePage(object sender, MouseButtonEventArgs e) =>
            DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.Create;


        private void SelectDeletePage(object sender, MouseButtonEventArgs e) =>
            DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.Delete;

        private void SelectExtractPage(object sender, MouseButtonEventArgs e) =>
            DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.Extract;

        private void SelectLicensePage(object sender, MouseButtonEventArgs e) =>
            DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.License;

        private void SelectWelcomePage(object sender, MouseButtonEventArgs e) =>
            DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.Welcome;

        private void SelectChangeGeneralPasswordPage(object sender, MouseButtonEventArgs e) =>
             DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.ChangeGeneralPassword;
    }
}
