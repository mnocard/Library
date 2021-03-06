using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Publisher
    {
        [Key, MaxLength(200)]
        public string PublisherName { get; set; }

        [Required, Column("Adress"), MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string EMail { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        public List<Book> Books { get; set; }

        public Publisher()
        {
            Books = new List<Book>();
        }
    }
}
