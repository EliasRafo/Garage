using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

            var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices(services =>
               {
                   services.AddSingleton<IConfiguration>(config);
                   services.AddSingleton<IUI, UI>();
                   services.AddSingleton<Manager>();
               })
               .UseConsoleLifetime()
               .Build();

            host.Services.GetRequiredService<Manager>().Run();
        }
    }
}