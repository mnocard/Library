using System.Collections.Generic;

using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface IBooksDBService
    {
        IEnumerable<Book> GetBooksWithoutAuthor();
        IEnumerable<Book> GetBooksWithFewGenres();
        IEnumerable<Book> GetPublichsersBooks();
    }
}
