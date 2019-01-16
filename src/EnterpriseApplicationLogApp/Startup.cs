using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnterpriseApplicationLogApp
{
    public class Startup
    {
        public static Configurations Configurations;

        static Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();

            Configurations = new Configurations();
            new ConfigureFromConfigurationOptions<Configurations>(configuration.GetSection("Configurations")).Configure(Configurations);
        }
    }
}
