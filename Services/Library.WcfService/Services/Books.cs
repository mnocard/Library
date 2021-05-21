using System.Collections.Generic;

using Library.DAL.Service;
using Library.Domain.Entities;
using Library.WcfService.Interfaces;

namespace Library.WcfService.Services
{
    public class Books : IBooksService
    {
        private BooksDBService _Service;
        public Books()
        {
            _Service = new BooksDBService();
        }

        public IEnumerable<Book> GetBooksWithFewGenres()
        {
            return _Service.GetBooksWithFewGenres();
        }

        public IEnumerable<Book> GetBooksWithoutAuthor()
        {
            return _Service.GetBooksWithoutAuthor();
        }

        public IEnumerable<Publisher> GetPublichsersBooks()
        {
            return _Service.GetPublichsersBooks();
        }
    }
}
