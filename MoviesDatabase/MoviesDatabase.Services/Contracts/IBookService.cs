using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IBookService
    {
        void AddBooks();

        Book CreateBook(string title, string author, int year);

        Book GetBookBy(string title);
    }
}
