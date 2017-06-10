using MoviesDatabase.Models;

namespace MoviesDatabase.Factories
{
    public interface IGenreFactory
    {
        Genre CreateGenre(string name);
    }
}
