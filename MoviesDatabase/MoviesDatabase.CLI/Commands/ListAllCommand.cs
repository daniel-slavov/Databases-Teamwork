using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Models;
using MoviesDatabase.Services.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class ListAllCommand : ICommand
    {
        private readonly IMovieService movieService;
        private readonly ITableCreator tableCreator;

        public ListAllCommand(IMovieService movieService, ITableCreator tableCreator)
        {
            if (movieService == null)
            {
                throw new ArgumentNullException("Movie service cannot be null.");
            }

            if (tableCreator == null)
            {
                throw new ArgumentNullException("Table creator cannot be null.");
            }

            this.movieService = movieService;
            this.tableCreator = tableCreator;
        }

        public string Execute(IList<string> parameters)
        {
            IEnumerable<Movie> movies = this.movieService.GetAllMovies();

            if (movies == null)
            {
                throw new ArgumentNullException("No movies to show.");
            }

            IEnumerable<MovieForPrint> moviesForPrint = this.movieService.ConvertForPrint(movies);

            return this.tableCreator.CreateTable<MovieForPrint>(moviesForPrint);
        }
    }
}
