using System.Collections.Generic;
using System.Linq;

using Library.DAL.Service;
using Library.WcfService.DataContractExtensions;
using Library.WcfService.DataContracts;
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

        public IEnumerable<BookType> GetBooksWithFewGenres()
        {
            var result = _Service.GetBooksWithFewGenres();
            return result.Select(b => b.ToDCT());
        }

        public IEnumerable<BookType> GetBooksWithoutAuthor()
        {
            var result = _Service.GetBooksWithoutAuthor();
            return result.Select(b => b.ToDCT());
        }

        public IEnumerable<PublisherType> GetPublichsersBooks()
        {
            var result = _Service.GetPublichsersBooks();
            return result.Select(b => b.ToDCT());
        }
    }
}
