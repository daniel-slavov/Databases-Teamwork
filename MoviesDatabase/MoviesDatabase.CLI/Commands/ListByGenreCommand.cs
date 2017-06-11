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
    public class ListByGenreCommand : ICommand
    {
        private readonly IMovieService movieService;
        private readonly ITableCreator tableCreator;

        public ListByGenreCommand(IMovieService movieService, ITableCreator tableCreator)
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
            IEnumerable<Movie> movies = this.movieService.GetMoviesByGenre(parameters[0]);

            if (movies == null)
            {
                throw new NullReferenceException("There is no movies in this genre.");
            }

            IEnumerable<MovieForPrint> moviesForPrint = this.movieService.ConvertForPrint(movies);

            return this.tableCreator.CreateTable<MovieForPrint>(moviesForPrint);
        }
    }
}
