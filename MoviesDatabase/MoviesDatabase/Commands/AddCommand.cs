using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class AddCommand : ICommand
    {
        private readonly IMovieService MovieService;
		private readonly IConsoleReader Reader;
		private readonly IConsoleWriter Writer;

		public AddCommand(IMovieService movieService, IConsoleReader reader, IConsoleWriter writer)
        {
            if (movieService == null)
            {
                throw new ArgumentNullException("Movie service cannot be null.");
            }

            if (reader == null)
			{
				throw new ArgumentNullException("Console reader cannot be null.");
			}

			if (writer == null)
			{
				throw new ArgumentNullException("Console writer cannot be null.");
			}

            this.MovieService = movieService;
			this.Reader = reader;
            this.Writer = writer;
		}

        string ICommand.Execute(IList<string> parameters)
        {
            string title = "";
            string description = "";
            string producer = "";
            string studio = "";
            string book = "";
            string inputGenres = "";
            string inputStars = "";
            int year = 0;
            int length = 0;
            IList<string> genres = new List<string>();
			IList<string> stars = new List<string>();

            while(string.IsNullOrWhiteSpace(title))
            {
                this.Writer.Write("Title: ");
                title = this.Reader.ReadLine();
            }

            while (year < 1)
            {
                this.Writer.Write("Year: ");
                int.TryParse(this.Reader.ReadLine(), out year);
            }

            while (string.IsNullOrWhiteSpace(description))
			{
				this.Writer.Write("Description: ");
				description = this.Reader.ReadLine();
			}

            while (year < 1)
            {
                this.Writer.Write("Length: ");
                length = int.Parse(this.Reader.ReadLine());
            }

            while (string.IsNullOrWhiteSpace(producer))
			{
				this.Writer.Write("Pruducer: ");
				producer = this.Reader.ReadLine();
			}

            while (string.IsNullOrWhiteSpace(studio))
			{
				this.Writer.Write("Studio: ");
				studio = this.Reader.ReadLine();
			}

			while (string.IsNullOrWhiteSpace(book))
			{
				this.Writer.Write("Book: ");
				book = this.Reader.ReadLine();
			}

            while (string.IsNullOrWhiteSpace(inputGenres))
            {
                this.Writer.Write("Genres: ");
                inputGenres = this.Reader.ReadLine();
				genres = inputGenres.Replace(", ", "_").Split('_');
            }

            while (string.IsNullOrWhiteSpace(inputStars))
            {
                this.Writer.Write("Stars: ");
                inputStars = this.Reader.ReadLine();
				stars = inputStars.Replace(", ", "_").Split('_');
            }

            this.MovieService.CreateMovie(title, year, description, length, producer, studio, book, genres, stars);

            return "Movie was added successfully.";
        }
    }
}
