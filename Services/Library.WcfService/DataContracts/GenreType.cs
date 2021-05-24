using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.WcfService.Interfaces
{
    [DataContract]
    [KnownType(typeof(List<Genres_BooksType>))]
    [KnownType(typeof(Genres_BooksType))]
    public class GenreType
    {
        [DataMember]
        public string GenreName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<Genres_BooksType> Genres_Books { get; set; } = new List<Genres_BooksType>();
    }
}
