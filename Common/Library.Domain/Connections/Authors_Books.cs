using Library.Domain.Entities;

namespace Library.Domain.Connections
{
    public class Authors_Books
    {
        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
