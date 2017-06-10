using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IBookService
    {
        void AddBooks(IList<Book> books);

        Book CreateBook(string title, string author, int? year);

        Book GetBookByTitle(string title);

        void UpdateBook(Book book);

        void DeleteBook(string title);
    }
}
