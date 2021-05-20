using System;
using System.Collections.Generic;
using System.Linq;

using Library.DAL.Interfaces;
using Library.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Service
{
    public class BookDBService : IBooksDBService
    {
        public IEnumerable<Book> GetBooksWithFewGenres()
        {
            using (var db = new BooksDBInitializer().CreateDbContext(null))
            {
                var books = db.Books.All(b => b.Genres_Books. > 1)
                db.SaveChanges();
            }
        }

        public IEnumerable<Book> GetBooksWithoutAuthor()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetPublichsersBooks()
        {
            throw new NotImplementedException();
        }
    }
}
