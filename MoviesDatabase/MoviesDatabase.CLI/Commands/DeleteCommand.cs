using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class DeleteCommand : ICommand
    {
        private readonly IBookService bookService;
        private readonly IMovieService movieService;
        private readonly IStarService starService;
        private readonly IStudioService studioService;

        public DeleteCommand(IBookService bookService, IMovieService movieService, IStarService starService, IStudioService studioService)
        {
            if (bookService == null)
            {
                throw new ArgumentNullException("Book service cannot be null.");
            }

            if (movieService == null)
            {
                throw new ArgumentNullException("Movie service cannot be null.");
            }

            if (starService == null)
            {
                throw new ArgumentNullException("Star service cannot be null.");
            }

            if (studioService == null)
            {
                throw new ArgumentNullException("Studio service cannot be null.");
            }

            this.bookService = bookService;
            this.movieService = movieService;
            this.starService = starService;
            this.studioService = studioService;
        }

        public string Execute(IList<string> parameters)
        {
            string model = parameters[0];
            string name = parameters[1].Replace('_', ' ');

            switch (model.ToLower())
            {
                case "book":
                    this.bookService.DeleteBook(name);
                    break;
                case "movie":
                    this.movieService.DeleteMovie(name);
                    break;
                case "star":
                    string firstName = name.Split(' ')[0];
                    string lastName = name.Split(' ')[1];

                    this.starService.DeleteStar(firstName, lastName);
                    break;
                case "studio":
                    this.studioService.DeleteStudio(name);
                    break;
                default:
                    throw new ArgumentException($"{model}s cannot be deleted.");
            }

            return $"{model} {name} was deleted successfully.";
        }
    }
}

// Sample command:
// Delete Studio Sony