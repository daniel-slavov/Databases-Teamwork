using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Services.Contracts;
using ConsoleTables;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Parsers;
using MoviesDatabase.Parsers.Models;

namespace MoviesDatabase.CLI.Commands
{
    public class ListAllCommand : ICommand
    {
        private readonly IMovieService MovieService;

        public ListAllCommand(IMovieService movieService)
        {
            if (movieService == null)
            {
                throw new ArgumentNullException("Movie service cannot be null.");
            }

            this.MovieService = movieService;
        }

        public string Execute(IList<string> parameters)
        {
            IEnumerable<Movie> movies = this.MovieService.GetAllMovies();
            IEnumerable<MovieForPrint> moviesForPrint = this.MovieService.ConvertForPrint(movies);

            return ConsoleTable.From<MovieForPrint>(moviesForPrint).ToString();
        }
    }
}
