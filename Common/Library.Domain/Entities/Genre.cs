using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Genre
    {
        [Required]
        public string GenreName { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
