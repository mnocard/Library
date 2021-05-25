using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.WcfService.DataContracts
{
    [DataContract]
    [KnownType(typeof(List<Authors_BooksType>))]
    [KnownType(typeof(Authors_BooksType))]

    public class AuthorType
    {
        [DataMember]
        public int AuthorID { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public List<Authors_BooksType> Authors_Books { get; set; } = new List<Authors_BooksType>();
    }
}
