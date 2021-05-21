using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.WcfService.Interfaces
{
    [DataContract]
    public class BookType
    {
        [DataMember]
        public int BookID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Year { get; set; }

        [DataMember]
        public List<Genres_BooksType> Genres_Books { get; set; }

        [DataMember]
        public List<Authors_BooksType> Authors_Books { get; set; }

        [DataMember]
        public PublisherType Publisher { get; set; }

        public BookType()
        {
            Genres_Books = new List<Genres_BooksType>();
            Authors_Books = new List<Authors_BooksType>();
        }
    }
}
