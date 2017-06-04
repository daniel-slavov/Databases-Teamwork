using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IGenreService
    {
        void AddGenres();

        Genre CreateGenre(string name);

        Genre GetGenreBy(string name);
    }
}
