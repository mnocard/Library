using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.WcfService.Interfaces
{
    [DataContract]
    public class GenreType
    {
        [DataMember]
        public string GenreName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<Genres_BooksType> Genres_Books { get; set; }

        public GenreType()
        {
            Genres_Books = new List<Genres_BooksType>();
        }
    }
}
