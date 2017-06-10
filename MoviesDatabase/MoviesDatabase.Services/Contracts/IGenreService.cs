using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IGenreService
    {
        void AddGenres(IList<Genre> genres);

        Genre CreateGenre(string name);

        Genre GetGenreBy(string name);
    }
}
