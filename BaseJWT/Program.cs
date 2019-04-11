using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BaseJWT.Infrastructure.EntityFramework.Seeder;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BaseJWT
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            SeedDb(host);

            host.Run();
        }
        private static void SeedDb(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<Seeder>();
                seeder.SeedAsync().Wait();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

        }

    }
}
