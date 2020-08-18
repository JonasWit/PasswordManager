using PasswordManager.Data;
using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager.Config
{
    public static class AppStartup
    {
        public static void Initialize()
        {
            Dependancies.DI.Startup();

            var filesHander = Dependancies.DI.Provider.GetService<FilesHandler>();
            filesHander.HandleRootFolder();

            PMContext.Startup();



        }
    }
}
