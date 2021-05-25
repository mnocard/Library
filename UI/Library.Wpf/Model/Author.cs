using System;
using System.Collections.Generic;

namespace Library.Wpf.Model
{
    public class Author
    {
        public int AuthorID { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public DateTime? Birthday { get; set; }

        public List<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}

