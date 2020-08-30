using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.BusinessLogic;
using PasswordManager.Config;
using PasswordManager.Controllers;
using PasswordManager.Data;
using PasswordManager.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;

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

            @this.AddDataProtection()
                   .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration()
                   {
                       EncryptionAlgorithm = EncryptionAlgorithm.AES_256_GCM,
                       ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                   });

            @this.AddTransient<IPasswordGenerator, PasswordGenerator>();
            @this.AddTransient<IAppRepository, AppRepository>();
            @this.AddSingleton(new ViewModelsController());
            @this.AddSingleton(new SystemData());
            @this.AddSingleton(new AppController());
            @this.AddHttpClient();
            @this.AddDbContext<PMContext>(options =>
                options.UseSqlite($"Data Source={Path.Combine(Definitions.CorePath, Definitions.DBName)}"),
                ServiceLifetime.Transient);

            return @this;
        }
    }
}
