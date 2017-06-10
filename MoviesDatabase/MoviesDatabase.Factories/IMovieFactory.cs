using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.Factories
{
    public interface IMovieFactory
    {
        Movie CreateMovie(string title, int year, string description, int length, Producer producer, Studio studio, Book book, ICollection<Genre> genres, ICollection<Star> stars);
    }
}
