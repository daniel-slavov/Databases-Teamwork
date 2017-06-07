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
            //         IJSONParser parser = new JSONParser();
            //         IEnumerable<MovieModel> allMovies = parser.Parse<MovieModel>("/Users/ds/Documents/Databases-Teamwork/MoviesDatabase/MoviesDatabase.Parsers/InitialData/movies.json");
            //         var table = ConsoleTable.From<MovieModel>(allMovies);
            //         var tableColumns = table.Columns;

            //tableColumns.RemoveAt(2);

            //Console.WriteLine(string.Join(", ", table.Columns));


            //return table.ToString();

            return "";
        }
    }
}
