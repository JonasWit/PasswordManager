using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.ViewModels;
using System.Threading.Tasks;

namespace PasswordManager.Controllers
{
    [Service]
    public class CreatePageController
    {

        public async Task GeneratePassword()
        {
            var vm = DI.Provider.GetService<ViewModelsController>().GetViewModel<CreateViewModel>();

            if (vm.Busy) return;
            else vm.Busy = true;

            try
            {
      
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                vm.Busy = false;
            }
        }

    }
}
