using System.Collections.Generic;
using System.ServiceModel;

using Library.Domain.Entities;

namespace Library.WcfService.Interfaces
{
    [ServiceContract]
    public interface IBooksService
    {
        [OperationContract]
        IEnumerable<Book> GetBooksWithoutAuthor();

        [OperationContract]
        IEnumerable<Book> GetBooksWithFewGenres();

        [OperationContract]
        IEnumerable<Publisher> GetPublichsersBooks();
    }
}
