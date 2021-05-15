using Library.DAL;
using Library.WcfService.Host.HostService;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Library.WcfService.Host
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var th = new TestHost();
            await Task.Run(() => th.Initialize());

            var db = new DBInitializer();
            await db.Initialize(GetConnectionString());
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