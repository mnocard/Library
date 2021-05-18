using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Publisher
    {
        [Key, Column(TypeName = "varchar(200)")]
        public string PublisherName { get; set; }

        [Required, Column("Adress", TypeName = "varchar(200)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string EMail { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }

        public List<Book> Books { get; set; }

        public Publisher()
        {
            Books = new List<Book>();
        }
    }
}
