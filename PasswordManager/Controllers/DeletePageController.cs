using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.ViewModels;
using System;
using System.Threading.Tasks;

namespace PasswordManager.Controllers
{
    [Service]
    public class DeletePageController
    {
        private readonly AppController appController;
        private readonly ViewModelsController viewModelsController;
        private readonly IAppRepository appRepository;

        public DeletePageController(AppController appController, ViewModelsController viewModelsController, IAppRepository appRepository)
        {
            this.appController = appController;
            this.viewModelsController = viewModelsController;
            this.appRepository = appRepository;
        }


        public async Task DeletePassword()
        {
            if (appController.Busy) return;
            else appController.EnableBusyState();

            var vm = viewModelsController.GetViewModel<DeleteViewModel>();

            if (vm.SelectedPassword == null)
            {
                appController.DisableBusyState();
                return;
            }

            try
            {
                await appRepository.DeletePassword(vm.SelectedPassword.Id);

                appController.RefreshViewModels();
            }
            catch (Exception)
            {

            }
            finally
            {
                appController.DisableBusyState();
            }
        }
    }
}
