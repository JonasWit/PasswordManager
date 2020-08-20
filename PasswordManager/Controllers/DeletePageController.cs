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
        public async Task DeletePassword()
        {
            var app = DI.Provider.GetService<AppController>();

            if (app.Busy) return;
            else app.EnableBusyState();

            var vmc = DI.Provider.GetService<ViewModelsController>();
            var vm = vmc.GetViewModel<DeleteViewModel>();

            if (vm.SelectedPassword == null)
            {
                app.DisableBusyState();
                return;
            }

            try
            {
                var repo = DI.Provider.GetService<IAppRepository>();
                await repo.DeletePassword(vm.SelectedPassword.Id);

                app.RefreshViewModels();
            }
            catch (Exception)
            {

            }
            finally
            {
                app.DisableBusyState();
            }
        }
    }
}
