using Library.DAL;

using Microsoft.EntityFrameworkCore;

using System.Text;
using System;
using System.IO;

namespace Library.WcfService.Host.DBService
{
    public class BooksService
    {
        public static void BooksDBCreate(string[] args)
        {
            var dbInitializer = new DBInitializer();
            using (var db = dbInitializer.CreateDbContext(args))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        public static void ChangeDBCollate(string[] args)
        {
            var dbInitializer = new DBInitializer();
            using (var db = dbInitializer.CreateDbContext(args))
            {
                db.Database.ExecuteSqlRaw("ALTER DATABASE CURRENT COLLATE Cyrillic_General_CI_AS");
                db.SaveChanges();
            }
        }

        public static void FillDbWithSqlScript(string[] args)
        {
            var dbInitializer = new DBInitializer();
            using (var db = dbInitializer.CreateDbContext(args))
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
