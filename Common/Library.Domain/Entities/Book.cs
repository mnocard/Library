using Library.Domain.Connections;
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
        public List<Genres_Books> Genres_Books { get; set; }
        public List<Authors_Books> Authors_Books { get; set; }
        public Publisher Publisher { get; set; }
        public Book()
        {
            Genres_Books = new List<Genres_Books>();
            Authors_Books = new List<Authors_Books>();
        }
    }
}
