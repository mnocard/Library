using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Publisher
    {
        public string PublisherName { get; set; }
        [Required]
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
