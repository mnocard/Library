using Library.Domain.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [Required, Column(TypeName = "varchar(50)")]
        public string Surname { get; set; }

        [Required, Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string MiddleName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public List<Authors_Books> Authors_Books { get; set; }

        public Author()
        {
            Authors_Books = new List<Authors_Books>();
        }
    }
}
