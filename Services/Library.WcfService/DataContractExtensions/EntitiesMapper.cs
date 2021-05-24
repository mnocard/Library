using System;
using System.Linq;

using Library.Domain.Connections;
using Library.Domain.Entities;
using Library.WcfService.DataContracts;

namespace Library.WcfService.DataContractExtensions
{
    public static class EntitiesMapper
    {
        public static Genres_Books FromDCT(this Genres_BooksType gb)
        {
            if (gb == null) return null;

            return new Genres_Books
            {
                BookID = gb.BookID,
                GenreName = gb.GenreName,
                Books = gb.Books.FromDCT(),
                Genre = gb.Genre.FromDCT(),
            };
        }

        public static Genres_BooksType ToDCT(this Genres_Books gb)
        {
            if (gb == null) return null;

            return new Genres_BooksType
            {
                BookID = gb.BookID,
                GenreName = gb.GenreName,
                Books = gb.Books.ToDCT(),
                Genre = gb.Genre.ToDCT(),
            };
        }

        public static Authors_Books FromDCT(this Authors_BooksType ab)
        {
            if (ab == null) return null;

            return new Authors_Books
            {
                AuthorID = ab.AuthorID,
                BookID = ab.BookID,
                Author = ab.Author.FromDCT(),
                Book = ab.Book.FromDCT(),
            };
        }

        public static Authors_BooksType ToDCT(this Authors_Books ab)
        {
            if (ab == null) return null;

            return new Authors_BooksType
            {
                AuthorID = ab.AuthorID,
                BookID = ab.BookID,
                Author = ab.Author.ToDCT(),
                Book = ab.Book.ToDCT(),
            };
        }

        public static Author FromDCT(this AuthorType a)
        {
            if (a == null) return null;

            return new Author
            {
                AuthorID = a.AuthorID,
                Birthday = a.Birthday,
                MiddleName = a.MiddleName,
                Name = a.Name,
                Surname = a.Surname,
                Authors_Books = a.Authors_Books.Select(FromDCT).ToList(),
            };
        }

        public static AuthorType ToDCT(this Author a)
        {
            if (a == null) return null;

            return new AuthorType
            {
                AuthorID = a.AuthorID,
                Birthday = a.Birthday ?? DateTime.MinValue,
                MiddleName = a.MiddleName,
                Name = a.Name,
                Surname = a.Surname,
                Authors_Books = a.Authors_Books.Select(ToDCT).ToList(),
            };
        }

        public static Book FromDCT(this BookType b)
        {
            if (b == null) return null;

            return new Book
            {
                BookID = b.BookID,
                Description = b.Description,
                Name = b.Name,
                Year = b.Year,
                PublisherName = b.PublisherName,
                Publisher = b.Publisher.FromDCT(),
                Authors_Books = b.Authors_Books.Select(FromDCT).ToList(),
                Genres_Books = b.Genres_Books.Select(FromDCT).ToList(),
            };
        }

        public static BookType ToDCT(this Book b)
        {
            if (b == null) return null;

            return new BookType
            {
                BookID = b.BookID,
                Description = b.Description,
                Name = b.Name,
                Year = b.Year,
                PublisherName = b.PublisherName,
                Authors_Books = b.Authors_Books.Select(ToDCT).ToList(),
                Genres_Books = b.Genres_Books.Select(ToDCT).ToList(),
            };
        }

        public static Genre FromDCT(this GenreType g)
        {
            if (g == null) return null;

            return new Genre
            {
                Description = g.Description,
                GenreName = g.GenreName,
                Genres_Books = g.Genres_Books.Select(FromDCT).ToList(),
            };
        }

        public static GenreType ToDCT(this Genre g)
        {
            if (g == null) return null;

            return new GenreType
            {
                Description = g.Description,
                GenreName = g.GenreName,
                Genres_Books = g.Genres_Books.Select(ToDCT).ToList(),
            };
        }

        public static Publisher FromDCT(this PublisherType p)
        {
            if (p == null) return null;

            return new Publisher
            {
                Address = p.Address,
                EMail = p.EMail,
                Phone = p.Phone,
                PublisherName = p.PublisherName,
                Books = p.Books.Select(FromDCT).ToList(),
            };
        }

        public static PublisherType ToDCT(this Publisher p)
        {
            if (p == null) return null;

            return new PublisherType
            {
                Address = p.Address,
                EMail = p.EMail,
                Phone = p.Phone,
                PublisherName = p.PublisherName,
                Books = p.Books.Select(ToDCT).ToList(),
            };
        }
    }
}
