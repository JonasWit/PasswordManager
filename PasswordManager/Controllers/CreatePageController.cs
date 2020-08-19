using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.ViewModels;
using System.Threading.Tasks;
using PasswordManager.Config;

namespace PasswordManager.Controllers
{
    [Service]
    public class CreatePageController
    {

        public void GeneratePassword()
        {
            var vm = DI.Provider.GetService<ViewModelsController>().GetViewModel<CreateViewModel>();

            if (vm.Busy) return;
            else vm.Busy = true;

            try
            {


                return;   
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
