using System;
using System.Collections.Generic;
using ConsoleTables;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class ListByStarCommand : ICommand
    {
		private readonly IMovieService MovieService;

        public ListByStarCommand(IMovieService movieService)
		{
			if (movieService == null)
			{
				throw new ArgumentNullException("Movie service cannot be null.");
			}

			this.MovieService = movieService;
		}

		public string Execute(IList<string> parameters)
		{
            string starName = string.Join(" ", parameters);
            
            IEnumerable<Movie> movies = this.MovieService.GetMoviesByStar(starName);
			IEnumerable<MovieForPrint> moviesForPrint = this.MovieService.ConvertForPrint(movies);

			return ConsoleTable.From<MovieForPrint>(moviesForPrint).ToString();
		}
    }
}
