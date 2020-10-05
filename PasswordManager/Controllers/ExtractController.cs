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
        private readonly AppController appController;
        private readonly Extractor extractor;

        public ExtractController(AppController appController, Extractor extractor)
        {
            this.appController = appController;
            this.extractor = extractor;
        }

        public async Task ExtractPasswords()
        {
            if (appController.Busy) return;
            else appController.EnableBusyState();

            try
            {
                await extractor.ExtractJson();
                await extractor.ExtractDatabase();

                appController.DisableBusyState();
                appController.ShowInfoPage("Success!", "Passwords extracted!");
            }
            catch (Exception)
            {
                appController.DisableBusyState();
                appController.ShowInfoPage("Issue!", "Please try again!");
            }
        }
    }
}
