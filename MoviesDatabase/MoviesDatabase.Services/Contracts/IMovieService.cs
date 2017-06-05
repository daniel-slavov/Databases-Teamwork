using System;
using System.Collections.Generic;
using MoviesDatabase.Models;
using MoviesDatabase.Models.Contracts;
using MoviesDatabase.Parsers.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IMovieService
    {
        void AddMovies(IList<MovieModel> movies);
        Movie CreateMovie(string title, int year, string description, int length, Producer producer, Studio studio, Book book);

        Movie GetMovieBy(string title);
    }
}
