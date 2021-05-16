using Library.Domain.Connections;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class BooksDB : DbContext
    {
        private readonly string _ConnectionString;

        public BooksDB(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors_Books>()
                .HasKey(t => new { t.AuthorID, t.BookID });

            modelBuilder.Entity<Authors_Books>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.Authors_Books)
                .HasForeignKey(ab => ab.AuthorID);

            modelBuilder.Entity<Authors_Books>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.Authors_Books)
                .HasForeignKey(ab => ab.BookID);


            modelBuilder.Entity<Genres_Books>()
                .HasKey(t => new { t.GenreName, t.BookID });

            modelBuilder.Entity<Genres_Books>()
                .HasOne(gb => gb.Books)
                .WithMany(b => b.Genres_Books)
                .HasForeignKey(gb => gb.BookID);

            modelBuilder.Entity<Genres_Books>()
                .HasOne(gb => gb.Genre)
                .WithMany(g => g.Genres_Books)
                .HasForeignKey(gb => gb.GenreName);
        }
    }
}
