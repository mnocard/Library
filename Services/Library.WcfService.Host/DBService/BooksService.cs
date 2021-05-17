using Library.DAL;

using System.Threading.Tasks;

namespace Library.WcfService.Host.DBService
{
    public class BooksService
    {
        public static async Task BooksDBInitialize(string[] args)
        {
            var dbInitializer = new DBInitializer();
            using (var db = dbInitializer.CreateDbContext(args))
            {
                var created = await db.Database.EnsureCreatedAsync();
            }
        }
    }
}
