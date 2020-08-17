using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Config;
using PasswordManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PasswordManager.DI
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var services = definedTypes
                .Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);

            foreach (var service in services)
            {
                @this.AddTransient(service);
            }

            @this.AddSingleton(new ViewModelsController());
            @this.AddSingleton(new SystemData());
            @this.AddSingleton(new LicenseHandler());
            @this.AddSingleton(new FilesHandler());
            @this.AddHttpClient();



            return @this;
        }
    }
}
