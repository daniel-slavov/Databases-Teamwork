using MoviesDatabase.Models;

namespace MoviesDatabase.Factories
{
    public interface IBookFactory
    {
        Book CreateBook(string title, string author, int? year);
    }
}
