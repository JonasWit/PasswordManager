using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.DI
{
    public static class DIProvider
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
