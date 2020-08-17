using PasswordManager.Data;
using PasswordManager.DI;
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
            DIProvider.Startup();

            var filesHander = DIProvider.Provider.GetService<FilesHandler>();
            filesHander.HandleRootFolder();

            PMContext.Startup();



        }
    }
}
