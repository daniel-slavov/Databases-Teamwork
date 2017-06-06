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

        Movie CreateMovie(string title, int year, string description, int length, string producerName, string studioName, string bookTitle, IEnumerable<string> genres, IEnumerable<string> stars);

        Movie GetMovieBy(string title);

        IEnumerable<Movie> GetMoviesByGenre(string genre);

        IEnumerable<Movie> GetAllMovies();

        void UpdateMovie(Movie movie);

        void DeleteMovie(string title);
    }
}
