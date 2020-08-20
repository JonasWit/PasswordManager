using Microsoft.Extensions.DependencyInjection;
using PasswordManager.BusinessLogic;
using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.Models;
using PasswordManager.ViewModels;
using System;
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
            var passwordReviewer = DI.Provider.GetService<PasswordReviewer>();

            if (string.IsNullOrEmpty(vm.Login) || 
                string.IsNullOrEmpty(vm.Name) || 
                string.IsNullOrEmpty(vm.Email) || 
                (string.IsNullOrEmpty(vm.Password) && 
                string.IsNullOrEmpty(vm.CustomPassword)))
            {
                app.DisableBusyState();
                return;
            }

            try
            {
                var repo = DI.Provider.GetService<IAppRepository>();

                var modelToAdd = new PasswordRecord
                {
                    Email = vm.Email,
                    Name = vm.Name,
                    Password = string.IsNullOrEmpty(vm.CustomPassword) ? vm.Password : vm.CustomPassword,
                    Lenght = string.IsNullOrEmpty(vm.CustomPassword) ? vm.Password.Length : vm.CustomPassword.Length,
                    Login = vm.Login,
                    LowerCases = string.IsNullOrEmpty(vm.CustomPassword) ? passwordReviewer.CheckLowerCase(vm.Password) : passwordReviewer.CheckLowerCase(vm.CustomPassword),
                    UpperCases = string.IsNullOrEmpty(vm.CustomPassword) ? passwordReviewer.CheckUpperCase(vm.Password) : passwordReviewer.CheckUpperCase(vm.CustomPassword),
                    NumbersCases = string.IsNullOrEmpty(vm.CustomPassword) ? passwordReviewer.CheckNumericCase(vm.Password) : passwordReviewer.CheckNumericCase(vm.CustomPassword),
                    SpecialCases = string.IsNullOrEmpty(vm.CustomPassword) ? passwordReviewer.CheckSpecialCase(vm.Password) : passwordReviewer.CheckSpecialCase(vm.CustomPassword),
                    PolishCases = string.IsNullOrEmpty(vm.CustomPassword) ? passwordReviewer.CheckPolishCase(vm.Password) : passwordReviewer.CheckPolishCase(vm.CustomPassword),
                };

                await repo.CreatePassword(modelToAdd);
   
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
