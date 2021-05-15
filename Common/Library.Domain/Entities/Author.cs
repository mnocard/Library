using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
