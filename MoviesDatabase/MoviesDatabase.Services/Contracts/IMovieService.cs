using System.Collections.Generic;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IMovieService
    {
        void AddMovies(IList<MovieModel> movies);

        Movie CreateMovie(string title, int year, string description, int length, string producerName, string studioName, string bookTitle, IEnumerable<string> genres, IEnumerable<string> stars);

        Movie GetMovieByTitle(string title);

        IEnumerable<Movie> GetMoviesByGenre(string genre);

        IEnumerable<Movie> GetMoviesByStar(string starName);

        IEnumerable<Movie> GetAllMovies();

        void DeleteMovie(string title);

        IEnumerable<MovieForPrint> ConvertForPrint(IEnumerable<Movie> movies);
    }
}
