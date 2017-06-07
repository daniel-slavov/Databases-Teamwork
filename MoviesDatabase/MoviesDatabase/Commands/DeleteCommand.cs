using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class DeleteCommand : ICommand
    {
        private readonly IMovieService MovieService;
        private readonly IStarService StarService;
        private readonly IBookService BookService;

        public DeleteCommand(IMovieService movieService, IStarService starService, IBookService bookService)
        {
            this.MovieService = movieService;
            this.StarService = starService;
            this.BookService = bookService;
        }

        public string Execute(IList<string> parameters)
        {
            string type = parameters[0];

            switch (type.ToLower())
            {
                case "star":
                    break;
                case "book":
                    break;
                case "movie":
                    break;
                default:
                    break;
            }
            return $"{type} deleted successfully.";
        }
    }
}
