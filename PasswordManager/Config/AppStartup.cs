using PasswordManager.Data;
using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.ViewModels;

namespace PasswordManager.Config
{
    public static class AppStartup
    {
        public static void Initialize()
        {
            DI.Startup();

            if (DI.Provider.GetService<FilesHandler>().HandleRootFolder())
            {
                var context = DI.Provider.GetService<PMContext>();
                context.Database.EnsureCreated();

                var vmc = DI.Provider.GetService<ViewModelsController>();
                vmc.CreateViewModel<GetGeneralPasswordViewModel>();
                vmc.CreateViewModel<WindowViewModel>();
            }
            else
            {

            }         
        }
    }
}
