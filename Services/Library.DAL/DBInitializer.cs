using System.IO;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Library.DAL
{
    public class DBInitializer : IDesignTimeDbContextFactory<BooksDB>
    {
        public BooksDB CreateDbContext(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(config.GetConnectionString("default"));

            return new BooksDB(optionsBuilder.Options);
        }
    }
}
