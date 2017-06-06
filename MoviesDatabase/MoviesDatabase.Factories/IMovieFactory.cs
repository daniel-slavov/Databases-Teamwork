using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Models;

namespace MoviesDatabase.Factories
{
    public interface IMovieFactory
    {
        Movie CreateMovie(string title, int year, string description, int length, Producer producer, Studio studio,
            Book book, IEnumerable<Genre> genres, IEnumerable<Star> stars);
    }
}
