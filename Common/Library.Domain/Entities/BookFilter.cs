using Library.Domain.Connections;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class BookFilter
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Year { get; set; }

        public List<Genres_Books> Genres_Books { get; set; } = new List<Genres_Books>();

        public List<Authors_Books> Authors_Books { get; set; } = new List<Authors_Books>();

        public Publisher Publisher { get; set; }
    }
}
