using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Library.DAL
{
    public class BooksDBInitializer : IDesignTimeDbContextFactory<BooksDBContext>
    {
        public BooksDBContext CreateDbContext(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(config.GetConnectionString("default"));

            return new BooksDBContext(optionsBuilder.Options);
        }

        public static void BooksDBCreate()
        {
            var dbInitializer = new BooksDBInitializer();
            using (var db = dbInitializer.CreateDbContext(null))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        public static void ChangeDBCollate()
        {
            var dbInitializer = new BooksDBInitializer();
            using (var db = dbInitializer.CreateDbContext(null))
            {
                db.Database.ExecuteSqlRaw("ALTER DATABASE CURRENT COLLATE Cyrillic_General_CI_AS");
                SqlConnection.ClearAllPools();
                db.SaveChanges();
            }
        }

        public static void FillDbWithSqlScript()
        {
            var dbInitializer = new BooksDBInitializer();
            using (var db = dbInitializer.CreateDbContext(null))
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    var script = File.ReadAllText(@"L:\Downloads\Insert (1).SQL", Encoding.Default);
                    var parts = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var part in parts)
                    {
                        db.Database.ExecuteSqlRaw(part);
                    }

                    db.SaveChanges();
                    dbContextTransaction.Commit();
                }
            }
        }
    }
}
