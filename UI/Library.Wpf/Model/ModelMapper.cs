
using System.Linq;

using Library.Wpf.ServiceReference2;

namespace Library.Wpf.Model
{
    public static class ModelMapper
    {
        public static Book ToVM(this BookType item)
        {
            if (item == null) return null;

            var book = new Book
            {
                BookID = item.BookID,
                Description = item.Description,
                Name = item.Name,
                PublisherName = item.PublisherName,
                Year = item.Year,
            };

            foreach (var author in item.Authors_Books)
            {
                book.Authors.Add(new Author
                {
                    AuthorID = author.Author.AuthorID,
                    Birthday = author.Author.Birthday,
                    MiddleName = author.Author.MiddleName,
                    Name = author.Author.MiddleName,
                    Surname = author.Author.Surname,
                });
            }

            foreach (var genre in item.Genres_Books)
            {
                book.Genres.Add(new Genre
                {
                    GenreName = genre.GenreName,
                });
            }

            return book;
        }

        public static Publisher ToVM(this PublisherType item)
        {
            if (item == null) return null;

            var publisher = new Publisher
            {
                Address = item.Address,
                EMail = item.EMail,
                Phone = item.Phone,
                PublisherName = item.PublisherName,
                Books = new System.Collections.Generic.List<Book>().Concat(item.Books.Select(ToVM)).ToList(),
            };
            return publisher;
        }
    }
}
