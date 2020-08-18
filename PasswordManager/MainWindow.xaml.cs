using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.ViewModels;
using PasswordManager.Controllers;
using PasswordManager.Data;
using PasswordManager.Config;

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

            Dependancies.DI.Provider.GetService<ViewModelsController>().CreateViewModel<WindowViewModel>();
            DataContext = Dependancies.DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>();
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
            Dependancies.DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.Dashboard;

        private void SelectCreatePage(object sender, MouseButtonEventArgs e) =>
            Dependancies.DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.Create;


        private void SelectDeletePage(object sender, MouseButtonEventArgs e) =>
            Dependancies.DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.Delete;

        private void SelectExtractPage(object sender, MouseButtonEventArgs e) =>
            Dependancies.DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.Extract;

        private void SelectLicensePage(object sender, MouseButtonEventArgs e) =>
            Dependancies.DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>().CurrentPage = Pages.AppPage.License;
    }
}
