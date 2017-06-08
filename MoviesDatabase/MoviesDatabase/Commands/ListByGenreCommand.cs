using System;
using System.Collections.Generic;
using ConsoleTables;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class ListByGenreCommand : ICommand
    {
		private readonly IMovieService MovieService;

        public ListByGenreCommand(IMovieService movieService)
		{
			if (movieService == null)
			{
				throw new ArgumentNullException("Movie service cannot be null.");
			}

			this.MovieService = movieService;
		}

		public string Execute(IList<string> parameters)
		{
            IEnumerable<Movie> movies = this.MovieService.GetMoviesByGenre(parameters[0]);
		    if (movies == null)
		    {
		        return "There is no movies in this genre.";
		    }
			IEnumerable<MovieForPrint> moviesForPrint = this.MovieService.ConvertForPrint(movies);

			return ConsoleTable.From<MovieForPrint>(moviesForPrint).ToString();
		}
    }
}
