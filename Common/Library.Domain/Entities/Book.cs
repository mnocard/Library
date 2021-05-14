using Library.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Book : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Year { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }
        public Publisher Publisher { get; set; }
    }
}
