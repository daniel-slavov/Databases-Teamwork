using System;
using System.Collections.Generic;
using ConsoleTables;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Models;
using MoviesDatabase.Services.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class ListByStarCommand : ICommand
    {
        private readonly IMovieService movieService;
        private readonly ITableCreator tableCreator;

        public ListByStarCommand(IMovieService movieService, ITableCreator tableCreator)
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
            string starName = string.Join(" ", parameters);

            IEnumerable<Movie> movies = this.movieService.GetMoviesByStar(starName);

            if (movies == null)
            {
                throw new NullReferenceException("This star has no movies to show.");
            }

            IEnumerable<MovieForPrint> moviesForPrint = this.movieService.ConvertForPrint(movies);

            return this.tableCreator.CreateTable<MovieForPrint>(moviesForPrint);
        }
    }
}
