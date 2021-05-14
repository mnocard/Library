using Library.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Author : Entity
    {
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
