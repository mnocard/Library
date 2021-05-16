using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.WcfService.Host.DBService
{
    public class BooksService
    {
        public static string GetConnectionString()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = configBuilder.Build();
            return config.GetConnectionString("default");
        }
    }
}
