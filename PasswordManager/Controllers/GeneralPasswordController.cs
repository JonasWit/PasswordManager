using PasswordManager.Config;
using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.ViewModels;
using System;

namespace PasswordManager.Controllers
{
    [Service]
    public class GeneralPasswordController
    {
        private readonly ViewModelsController _viewModelsController;
        private readonly AppController _appController;
        private readonly IAppRepository _repo;

        public GeneralPasswordController(ViewModelsController viewModelsController, AppController appController, IAppRepository repo)
        {
            _viewModelsController = viewModelsController;
            _appController = appController;
            _repo = repo;
        }

        public void ApplyGeneralPassword()
        {
            var vm = _viewModelsController.GetViewModel<GetGeneralPasswordViewModel>();
            var mainFormVm = _viewModelsController.GetViewModel<WindowViewModel>();

            try
            {
                if (string.IsNullOrEmpty(vm.Password)) return;

                mainFormVm.CurrentPage = Pages.AppPage.Loading;
                Definitions.GeneralPassword = vm.Password;

                _viewModelsController.CreateViewModel<CreateViewModel>();
                _viewModelsController.CreateViewModel<DashboardViewModel>();
                _viewModelsController.CreateViewModel<DeleteViewModel>();
                _viewModelsController.CreateViewModel<WelcomeViewModel>();
                _viewModelsController.CreateViewModel<ExtractViewModel>();
                _viewModelsController.CreateViewModel<InfoViewModel>();
                _viewModelsController.CreateViewModel<ChangeGeneralPasswordViewModel>();

                mainFormVm.CurrentPage = Pages.AppPage.Welcome;
                mainFormVm.GeneralPasswordProvided = true;
                vm.Password = "";
            }
            catch (Exception)
            {
                vm.Password = "Wystąpił błąd, spróbuj jeszcze raz";
            }
        }

        public void ChangeGeneralPassword()
        {
            var mainFormVm = _viewModelsController.GetViewModel<WindowViewModel>();

            if (_appController.Busy)
            {
                return;
            }
            else
            {
                _appController.EnableBusyState();
            }

            var vm = _viewModelsController.GetViewModel<ChangeGeneralPasswordViewModel>();

            try
            {   
                _repo.ChangeGeneralPassword(vm.NewPassword);
                Definitions.GeneralPassword = "";
            }
            catch (Exception)
            {
                vm.NewPassword = "Wystąpił błąd, spróbuj jeszcze raz";
            }
            finally
            {
                _appController.DisableBusyState();
                mainFormVm.GeneralPasswordProvided = false;
                mainFormVm.CurrentPage = Pages.AppPage.GetGeneralPassword;
            }
        }
    }
}
