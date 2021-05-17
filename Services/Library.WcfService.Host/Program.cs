using Library.DAL;

using Microsoft.Extensions.Configuration;

using System.IO;
using System.Threading.Tasks;

namespace Library.WcfService.Host
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var dbInitializer = new DBInitializer();
            using (var db = dbInitializer.CreateDbContext(args))
            {
                var created = await db.Database.EnsureCreatedAsync();
            }

            //var th = new TestHost();
            //await Task.Run(() => th.Initialize());
        }
    }
}