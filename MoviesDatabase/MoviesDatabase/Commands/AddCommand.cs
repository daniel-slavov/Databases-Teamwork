using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;
using MoviesDatabase.Models;

namespace MoviesDatabase.CLI.Commands
{
    public class AddCommand : ICommand
    {
        private readonly IMovieService MovieService;

        public AddCommand(IMovieService movieService)
        {
            if (movieService == null)
            {
                throw new ArgumentNullException("Movie service cannot be null.");
            }

            this.MovieService = movieService;
        }

        public string Execute(IList<string> parameters)
        {
            //this.service.CreateMovie("title", 2000, "test", 120, new Producer(), new Studio(), new Book());

            //var testMovie = new Movie("testtittle", 2000, "test", 120, new Producer(), new Studio(), new Book(), new List<Genre>(), new List<Star>());
            //Console.WriteLine(testMovie.GetType().GetProperty("Title").GetValue(testMovie, null));

            return "Command executed successfully.";
        }
    }
}
