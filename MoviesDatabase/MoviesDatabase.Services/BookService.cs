using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.Services
{
    public class BookService : IBookService
    {
        private const string filePath = "...";
        private readonly IRepository<Book> bookRepository;
        private readonly IJSONParser jsonParser;
        private readonly IBookFactory bookFactory;

        public BookService(IRepository<Book> bookRepository, IJSONParser jsonParser, IBookFactory bookFactory)
        {
            if (bookRepository == null)
            {
                throw new ArgumentNullException("Book repository cannot be null!");
            }

            if (jsonParser == null)
            {
                throw new ArgumentNullException("Json parser cannot be null!");
            }

            if (bookFactory == null)
            {
                throw new ArgumentNullException("Book factory cannot be null!");
            }

            this.bookRepository = bookRepository;
            this.jsonParser = jsonParser;
            this.bookFactory = bookFactory;
        }

        public void AddBooks()
        {
            var books = this.jsonParser.Parse<Book>(filePath);
            foreach (var book in books)
            {
                this.bookRepository.Add(book);
            }
        }

        public Book CreateBook(string title, string author, int year)
        {
            var book = this.bookFactory.CreateBook(title, author, year);
            this.bookRepository.Add(book);

            return book;
        }

        public Book GetBookBy(string title)
        {
            var book = this.bookRepository.Entities
                .FirstOrDefault(b => b.Title == title);

            return book;
        }
    }
}
