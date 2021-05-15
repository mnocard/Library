using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Genre
    {
        [Key, MaxLength(50)]
        public string GenreName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
