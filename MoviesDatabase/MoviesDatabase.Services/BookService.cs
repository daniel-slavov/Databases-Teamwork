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
        private readonly IRepository<Book> bookRepository;
        private readonly IBookFactory bookFactory;

        public BookService(IRepository<Book> bookRepository, IBookFactory bookFactory)
        {
            if (bookRepository == null)
            {
                throw new ArgumentNullException("Book repository cannot be null!");
            }

            if (bookFactory == null)
            {
                throw new ArgumentNullException("Book factory cannot be null!");
            }

            this.bookRepository = bookRepository;
            this.bookFactory = bookFactory;
        }

        public void AddBooks(IList<Book> books)
        {
            foreach (var book in books)
            {
                this.bookRepository.Add(book);
            }
        }

        public Book CreateBook(string title, string author, int? year)
        {
            var book = this.bookFactory.CreateBook(title, author, year);
            this.bookRepository.Add(book);

            return book;
        }

        public Book GetBookByTitle(string title)
        {
            var book = this.bookRepository.Entities
                .FirstOrDefault(b => b.Title == title);

            return book;
        }

        public void UpdateBook(Book book)
        {
            this.bookRepository.Update(book);
        }

        public void DeleteBook(string title)
        {
            var book = GetBookByTitle(title);
            this.bookRepository.Delete(book);
        }
    }
}
