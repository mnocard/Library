using System.Collections.Generic;

namespace Library.Wpf.Model
{
    public class Genre
    {
        public string GenreName { get; set; }

        public string Description { get; set; }

        public List<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}

