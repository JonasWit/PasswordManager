using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.Models;
using PasswordManager.ViewModels;
using System.Windows.Controls;

namespace PasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();

            var vmc = DI.Provider.GetService<ViewModelsController>();
            DataContext = vmc.GetViewModel<DashboardViewModel>();
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var data = sender as DataGrid;
            var selectedData = data.SelectedCells[0];

            if (selectedData.Column.Header.ToString() == "Password")
            {
                var vmc = DI.Provider.GetService<ViewModelsController>();
                vmc.GetViewModel<DashboardViewModel>().RefreshPasswordSplitter(selectedData.Item as PasswordRecord);
            }
        }
    }
}
