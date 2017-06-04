using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Models;

namespace MoviesDatabase.Factories
{
    public interface IGenreFactory
    {
        Genre CreateGenre(string name);
    }
}
