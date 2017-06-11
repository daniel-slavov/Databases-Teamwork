using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class AddCommand : ICommand
    {
        private readonly IMovieService movieService;
        private readonly IReader reader;
        private readonly IWriter writer;

        public AddCommand(IMovieService movieService, IReader reader, IWriter writer)
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

            this.movieService = movieService;
            this.reader = reader;
            this.writer = writer;
        }

        public string Execute(IList<string> parameters)
        {
            string title = string.Empty;
            string description = string.Empty;
            string producer = string.Empty;
            string studio = string.Empty;
            string book = string.Empty;
            string inputGenres = string.Empty;
            string inputStars = string.Empty;
            int year = 0;
            int length = 0;
            IList<string> genres = new List<string>();
            IList<string> stars = new List<string>();

            while (string.IsNullOrWhiteSpace(title))
            {
                this.writer.Write("Title: ");
                title = this.reader.ReadLine();
            }

            while (year < 1)
            {
                this.writer.Write("Year: ");
                int.TryParse(this.reader.ReadLine(), out year);
            }

            while (string.IsNullOrWhiteSpace(description))
            {
                this.writer.Write("Description: ");
                description = this.reader.ReadLine();
            }

            while (year < 1)
            {
                this.writer.Write("Length: ");
                length = int.Parse(this.reader.ReadLine());
            }

            while (string.IsNullOrWhiteSpace(producer))
            {
                this.writer.Write("Pruducer: ");
                producer = this.reader.ReadLine();
            }

            while (string.IsNullOrWhiteSpace(studio))
            {
                this.writer.Write("Studio: ");
                studio = this.reader.ReadLine();
            }

            while (string.IsNullOrWhiteSpace(book))
            {
                this.writer.Write("Book: ");
                book = this.reader.ReadLine();
            }

            while (string.IsNullOrWhiteSpace(inputGenres))
            {
                this.writer.Write("Genres: ");
                inputGenres = this.reader.ReadLine();
                genres = inputGenres.Replace(", ", "_").Split('_');
            }

            while (string.IsNullOrWhiteSpace(inputStars))
            {
                this.writer.Write("Stars: ");
                inputStars = this.reader.ReadLine();
                stars = inputStars.Replace(", ", "_").Split('_');
            }

            this.movieService.CreateMovie(title, year, description, length, producer, studio, book, genres, stars);

            return "Movie was added successfully.";
        }
    }
}