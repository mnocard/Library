using System.Collections.Generic;
using System.Linq;

using Library.DAL.Interfaces;
using Library.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Service
{
    public class BooksDBService : IBooksDBService
    {
        public IEnumerable<Book> GetBooksWithFewGenres()
        {
            using (var db = new BooksDBInitializer().CreateDbContext(null))
            {
                return db.Books.Where(b => b.Genres_Books.Count > 1).Select(b => b).ToList();
            }
        }

        public IEnumerable<Book> GetBooksWithoutAuthor()
        {
            using (var db = new BooksDBInitializer().CreateDbContext(null))
            {
                return db.Books.Where(b => b.Authors_Books.Count == 0).Select(b => b).ToList();
            }
        }

        public IEnumerable<Publisher> GetPublichsersBooks()
        {
            using (var db = new BooksDBInitializer().CreateDbContext(null))
            {
                return db.Publishers.Include(p => p.Books).ToList();
            }
        }
    }
}
