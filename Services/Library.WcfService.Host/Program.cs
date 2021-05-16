using Library.DAL;
using Library.WcfService.Host.HostService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;

namespace Library.WcfService.Host
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var dbInit = new DBInitializer();
            await dbInit.Initialize(GetConnectionString());

            //var th = new TestHost();
            //await Task.Run(() => th.Initialize());
        }

        private static string GetConnectionString()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = configBuilder.Build();
            return config.GetConnectionString("default");
        }
    }
}