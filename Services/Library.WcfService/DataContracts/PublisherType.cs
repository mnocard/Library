using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.WcfService.DataContracts
{

    [DataContract]
    [KnownType(typeof(List<BookType>))]
    [KnownType(typeof(BookType))]
    public class PublisherType
    {
        [DataMember]
        public string PublisherName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string EMail { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public List<BookType> Books { get; set; } = new List<BookType>();
    }
}
