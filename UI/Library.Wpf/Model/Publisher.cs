using System.Collections.Generic;

namespace Library.Wpf.Model
{
    public class Publisher
    {
        public string PublisherName { get; set; }

        public string Address { get; set; }

        public string EMail { get; set; }

        public string Phone { get; set; }

        public List<Book> Books { get; set; }

        public Publisher()
        {
            Books = new List<Book>();
        }
    }
}

