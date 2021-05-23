using System.Runtime.Serialization;

namespace Library.WcfService.Interfaces
{
    [DataContract]
    [KnownType(typeof(AuthorType))]
    [KnownType(typeof(BookType))]
    public class Authors_BooksType
    {
        [DataMember]
        public int AuthorID { get; set; }
        [DataMember]
        public AuthorType Author { get; set; }

        [DataMember]
        public int BookID { get; set; }
        [DataMember]
        public BookType Book { get; set; }
    }
}
