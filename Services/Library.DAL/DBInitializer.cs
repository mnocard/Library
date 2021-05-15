using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class DBInitializer
    {
        public async Task Initialize()
        {
            var config = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BooksDB;Integrated Security=True";

            using(var db = new BooksDB(new DbContextOptionsBuilder<BooksDB>().UseSqlServer(config).Options))
            {
                var created = await db.Database.EnsureCreatedAsync();
            }
        }
    }
}
