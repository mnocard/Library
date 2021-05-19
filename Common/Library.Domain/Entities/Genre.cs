using Library.Domain.Connections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Genre
    {
        [Key, Column(TypeName = "varchar(50)")]
        public string GenreName { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }

        public List<Genres_Books> Genres_Books { get; set; }

        public Genre()
        {
            Genres_Books = new List<Genres_Books>();
        }
    }
}
