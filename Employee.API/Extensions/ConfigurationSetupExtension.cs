using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Extensions
{
    public static class ConfigurationSetupExtension
    {
        public static IConfiguration GetConfig(bool isDevelopment)
        {
            return isDevelopment ? new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build()
                :
                new ConfigurationBuilder()
                   .AddEnvironmentVariables()
                   .Build();
        }
    }
}
