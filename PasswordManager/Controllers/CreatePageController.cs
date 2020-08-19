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

        public Task<ControllerActionResult> GeneratePassword()
        {
            var vm = DI.Provider.GetService<ViewModelsController>().GetViewModel<CreateViewModel>();
            var app = DI.Provider.GetService<AppController>();

            if (app.Busy) return Task.Run(() => { return ControllerActionResult.Failed; });
            else app.EnableBusyState();

            try
            {
                return Task.Run(() => { return ControllerActionResult.Ok; }); 
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                //app.DisableBusyState();
            }
        }


    }
}
