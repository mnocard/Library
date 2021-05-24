using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.WcfService.Interfaces
{
    [DataContract]
    [KnownType(typeof(List<Genres_BooksType>))]
    [KnownType(typeof(List<Authors_BooksType>))]
    [KnownType(typeof(Genres_BooksType))]
    [KnownType(typeof(Authors_BooksType))]
    [KnownType(typeof(PublisherType))]
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
        public List<Genres_BooksType> Genres_Books { get; set; } = new List<Genres_BooksType>();

        [DataMember]
        public List<Authors_BooksType> Authors_Books { get; set; } = new List<Authors_BooksType>();

        [DataMember]
        public PublisherType Publisher { get; set; }
    }
}
