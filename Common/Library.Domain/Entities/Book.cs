using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required, MaxLength(4)]
        public string Year { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
