using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.ViewModels;
using PasswordManager.Infrastructure;
using System.Collections.ObjectModel;
using PasswordManager.Models;

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
            var dashboardVm = vmc.GetViewModel<DashboardViewModel>();
            var deleteVm = vmc.GetViewModel<DeleteViewModel>();

            if (vm.SelectedPassword == null)
            {
                app.DisableBusyState();
                return;
            }

            try
            {
                var repo = DI.Provider.GetService<IAppRepository>();
                await repo.DeletePassword(vm.SelectedPassword.Id);

                dashboardVm.Passwords = new ObservableCollection<PasswordRecord>(repo.GetPasswords());
                deleteVm.Passwords = new ObservableCollection<PasswordRecord>(repo.GetPasswords());
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
