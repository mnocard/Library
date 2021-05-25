using System.Collections.Generic;
using System.Windows.Media;

namespace Library.Wpf.Model
{
    public class Book
    {
        public int BookID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Year { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Author> Authors { get; set; }

        public string PublisherName { get; set; }

        public Publisher Publisher { get; set; }

        public Book()
        {
            Genres = new List<Genre>();
            Authors = new List<Author>();
        }
    }
}

