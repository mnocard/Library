using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Library.DAL
{
    public class DBInitializer
    {
        public async Task Initialize(string ConnectionString)
        {
            using (var db = new BooksDB(ConnectionString))
            {
                var created = await db.Database.EnsureCreatedAsync();
            }
        }
    }
}
