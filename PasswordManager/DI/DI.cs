using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Dependancies
{
    public static class DI
    {
        public static IServiceProvider Provider { get; private set; }

        public static void Startup()
        {
            var services = new ServiceCollection();

            services.AddApplicationServices();
            Provider = services.BuildServiceProvider();
        }
    }
}
