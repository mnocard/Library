using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class BooksDB : DbContext
    {
        public BooksDB(DbContextOptions<BooksDB> opt) : base(opt) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
