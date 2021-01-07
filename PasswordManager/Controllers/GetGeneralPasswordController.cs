using PasswordManager.Config;
using PasswordManager.Dependancies;
using PasswordManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Controllers
{
    [Service]
    public class GetGeneralPasswordController
    {
        private readonly ViewModelsController _viewModelsController;

        public GetGeneralPasswordController(ViewModelsController viewModelsController)
        {
            _viewModelsController = viewModelsController;
        }

        public void ApplyGeneralPassword()
        {
            var vm = _viewModelsController.GetViewModel<GetGeneralPasswordViewModel>();
            var mainFormVm = _viewModelsController.GetViewModel<WindowViewModel>();
      
            if (string.IsNullOrEmpty(vm.Password)) return;

            mainFormVm.CurrentPage = Pages.AppPage.Loading;
            Definitions.GeneralPassword = vm.Password;

            _viewModelsController.CreateViewModel<CreateViewModel>();
            _viewModelsController.CreateViewModel<DashboardViewModel>();
            _viewModelsController.CreateViewModel<DeleteViewModel>();
            _viewModelsController.CreateViewModel<WelcomeViewModel>();
            _viewModelsController.CreateViewModel<ExtractViewModel>();
            _viewModelsController.CreateViewModel<InfoViewModel>();

            mainFormVm.CurrentPage = Pages.AppPage.Welcome;
            mainFormVm.GeneralPasswordProvided = true;
        }
    }
}
