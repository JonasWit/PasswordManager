using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.BusinessLogic;
using PasswordManager.Config;
using PasswordManager.Controllers;
using PasswordManager.Data;
using PasswordManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PasswordManager.Dependancies
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

            @this.AddTransient<IPasswordGenerator, PasswordGenerator>();
            @this.AddTransient<IAppRepository, AppRepository>();
            @this.AddSingleton(new ViewModelsController());
            @this.AddSingleton(new SystemData());
            @this.AddSingleton(new AppController());
            @this.AddHttpClient();
            @this.AddDbContext<PMContext>(options =>
                options.UseSqlite($"Data Source={Path.Combine(Definitions.CorePath, Definitions.DBName)}"));

            return @this;
        }
    }
}
