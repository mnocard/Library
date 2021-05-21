using System.Collections.Generic;
using System.ServiceModel;

namespace Library.WcfService.Interfaces
{
    [ServiceContract]
    public interface IBooksService
    {
        [OperationContract]
        IEnumerable<BookType> GetBooksWithoutAuthor();

        [OperationContract]
        IEnumerable<BookType> GetBooksWithFewGenres();

        [OperationContract]
        IEnumerable<PublisherType> GetPublichsersBooks();
    }
}
