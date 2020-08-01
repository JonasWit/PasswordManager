using Microsoft.Extensions.DependencyInjection;
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

            //@this.AddSingleton(new ViewModelsController());
            //@this.AddSingleton(new FilesManager());

            return @this;
        }
    }
}
