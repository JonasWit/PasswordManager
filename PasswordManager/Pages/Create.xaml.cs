using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
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

namespace PasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create()
        {
            InitializeComponent();

            Dependancies.DI.Provider.GetService<ViewModelsController>().CreateViewModel<CreateViewModel>();
            DataContext = Dependancies.DI.Provider.GetService<ViewModelsController>().GetViewModel<CreateViewModel>();
        }
    }
}
