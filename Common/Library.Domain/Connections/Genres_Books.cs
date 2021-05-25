using Library.Domain.Entities;

namespace Library.Domain.Connections
{
    public class Genres_Books
    {
        public string GenreName { get; set; }
        public Genre Genre { get; set; }
        public int BookID { get; set; }
        public Book Books { get; set; }
    }
}
