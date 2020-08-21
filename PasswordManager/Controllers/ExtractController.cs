using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Config;
using PasswordManager.Dependancies;
using System;
using System.Reflection;
using System.Threading.Tasks;


namespace PasswordManager.Controllers
{
    [Service]
    public class ExtractController
    {
        public async Task ExtractPasswords()
        {
            var app = DI.Provider.GetService<AppController>();
            var extractor = DI.Provider.GetService<Extractor>();

            if (app.Busy) return;
            else app.EnableBusyState();

            try
            {
                await extractor.ExtractJson();
                await extractor.ExtractDatabase();
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
