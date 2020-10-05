using PasswordManager.Dependancies;
using PasswordManager.ViewModels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Controllers
{
    [Service]
    public class InfoController
    {
        private readonly ViewModelsController viewModelsController;

        public InfoController(ViewModelsController viewModelsController)
        {
            this.viewModelsController = viewModelsController;
        }   

        public void Dismiss()
        {
            var vm = viewModelsController.GetViewModel<InfoViewModel>();
            var windowVm = viewModelsController.GetViewModel<WindowViewModel>();

            vm.InfoMessage = "";
            vm.InfoTitle = "";

            windowVm.CurrentPage = Pages.AppPage.Dashboard;
        }

        public void ShowMessage(string title, string message)
        {
            var vm = viewModelsController.GetViewModel<InfoViewModel>();
            var windowVm = viewModelsController.GetViewModel<WindowViewModel>();

            vm.InfoMessage = message;
            vm.InfoTitle = title;

            windowVm.CurrentPage = Pages.AppPage.Info;
        }
    }
}
