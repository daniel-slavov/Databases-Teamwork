using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class DeleteCommand : ICommand
    {
		private readonly IBookService BookService;
		private readonly IMovieService MovieService;
        private readonly IStarService StarService;
        private readonly IStudioService StudioService;

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

			this.BookService = bookService;
			this.MovieService = movieService;
            this.StarService = starService;
            this.StudioService = studioService;
        }

        public string Execute(IList<string> parameters)
        {
            string type = parameters[0];

            switch (type.ToLower())
            {
                case "book":
                    string bookName = parameters[1];

                    this.BookService.DeleteBook(bookName);

					return $"Book {bookName} was deleted successfully.";
				case "movie":
                    string movieTitle = parameters[1];

                    this.MovieService.DeleteMovie(movieTitle);

                    return $"Movie {movieTitle} was deleted successfully.";
				case "star":
                    string firstName = parameters[1];
                    string lastName = parameters[2];

                    this.StarService.DeleteStar(firstName, lastName);

                    return $"Star {firstName} {lastName} was deleted successfully.";
				case "studio":
                    string studioName = parameters[1];

                    this.StudioService.DeleteStudio(studioName);

					return $"Studio {studioName} was deleted successfully.";
				default:
                    return $"{type} cannot be deleted.";
            }
        }
    }
}
