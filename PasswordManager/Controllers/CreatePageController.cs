using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.Models;
using PasswordManager.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager.Controllers
{
    [Service]
    public class CreatePageController
    {
        public async Task GeneratePassword()
        {
            var app = DI.Provider.GetService<AppController>();

            if (app.Busy) return;
            else app.EnableBusyState();

            var vm = DI.Provider.GetService<ViewModelsController>().GetViewModel<CreateViewModel>();

            if (string.IsNullOrEmpty(vm.Login) || 
                string.IsNullOrEmpty(vm.Name))
            {
                app.DisableBusyState();
                return;
            }

            IPasswordGenerator passwordGenerator = DI.Provider.GetService<IPasswordGenerator>();

            try
            {
                vm.Password = await Task.Run(() => passwordGenerator.GeneratePassword(vm.UserLower, vm.UseUpper, vm.UseNumber, vm.UseSpecial, vm.UsePolish, vm.PasswordLenght));

                app.ActivePassword = new PasswordRecord
                {
                    Name = vm.Name,
                    Password = vm.Password,
                    Lenght = vm.PasswordLenght,
                    Login = vm.Login,
                    LowerCases = vm.UserLower,
                    UpperCases = vm.UseUpper,
                    NumbersCases = vm.UseNumber,
                    PolishCases = vm.UsePolish,
                    SpecialCases = vm.UseSpecial
                };
            }
            catch (Exception)
            {
                vm.Password = "Issue while generating password, please try again...";
            }
            finally
            {
                app.DisableBusyState();
            }
        }

        public async Task SavePassword()
        {
            var app = DI.Provider.GetService<AppController>();

            if (app.Busy) return;
            else app.EnableBusyState();

            var vmc = DI.Provider.GetService<ViewModelsController>();
            var vm = vmc.GetViewModel<CreateViewModel>();
            var dashboardVm = vmc.GetViewModel<DashboardViewModel>();

            if (string.IsNullOrEmpty(vm.Login) || 
                string.IsNullOrEmpty(vm.Name) || 
                string.IsNullOrEmpty(vm.Password))
            {
                app.DisableBusyState();
                return;
            }

            try
            {
                var repo = DI.Provider.GetService<IAppRepository>();
                await repo.CreatePassword(app.ActivePassword);
                dashboardVm.Passwords = new ObservableCollection<PasswordRecord>(repo.GetPasswords());
            }
            catch (Exception)
            {

            }
            finally
            {
                app.DisableBusyState();
            }
        }

        public void CopyPassword()
        {
            var vm = DI.Provider.GetService<ViewModelsController>().GetViewModel<CreateViewModel>();

            if (!string.IsNullOrEmpty(vm.Password))
            {
                Clipboard.SetDataObject(vm.Password);
            }
        }
    }
}
