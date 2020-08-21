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
        private readonly AppController appController;
        private readonly ViewModelsController viewModelsController;
        private readonly PasswordReviewer passwordReviewer;
        private readonly IPasswordGenerator passwordGenerator;
        private readonly IAppRepository appRepository;

        public CreatePageController(
            AppController appController, 
            ViewModelsController viewModelsController, 
            PasswordReviewer passwordReviewer, 
            IPasswordGenerator passwordGenerator,
            IAppRepository appRepository)
        {
            this.appController = appController;
            this.viewModelsController = viewModelsController;
            this.passwordReviewer = passwordReviewer;
            this.passwordGenerator = passwordGenerator;
            this.appRepository = appRepository;
        }

        public async Task GeneratePassword()
        {
            if (appController.Busy) return;
            else appController.EnableBusyState();

            var vm = viewModelsController.GetViewModel<CreateViewModel>();

            if (string.IsNullOrEmpty(vm.Login) || 
                string.IsNullOrEmpty(vm.Name))
            {
                appController.DisableBusyState();
                return;
            }

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
                appController.DisableBusyState();
            }
        }

        public async Task SavePassword()
        {
            if (appController.Busy) return;
            else appController.EnableBusyState();

            var vm = viewModelsController.GetViewModel<CreateViewModel>();

            if (string.IsNullOrEmpty(vm.Login) || 
                string.IsNullOrEmpty(vm.Name) || 
                string.IsNullOrEmpty(vm.Email) || 
                (string.IsNullOrEmpty(vm.Password) && 
                string.IsNullOrEmpty(vm.CustomPassword)))
            {
                appController.DisableBusyState();
                return;
            }

            try
            {
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

                await appRepository.CreatePassword(modelToAdd);

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

        public void CopyPassword()
        {
            var vm = viewModelsController.GetViewModel<CreateViewModel>();

            if (!string.IsNullOrEmpty(vm.Password))
            {
                Clipboard.SetDataObject(vm.Password);
            }
        }
    }
}
