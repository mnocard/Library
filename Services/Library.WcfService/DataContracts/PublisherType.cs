using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.WcfService.Interfaces
{

    [DataContract]
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
        public List<BookType> Books { get; set; }

        public PublisherType()
        {
            Books = new List<BookType>();
        }
    }
}
