using System.Runtime.Serialization;

namespace Library.WcfService.Interfaces
{
    [DataContract]
    [KnownType(typeof(GenreType))]
    [KnownType(typeof(BookType))]
    public class Genres_BooksType
    {
        [DataMember]
        public string GenreName { get; set; }
        [DataMember]
        public GenreType Genre { get; set; }
        [DataMember]
        public int BookID { get; set; }
        [DataMember]
        public BookType Books { get; set; }
    }
}
