using System.Linq;
using MoviesDatabase.Models;

namespace MoviesDatabase.Parsers.Models
{
    public class MovieForPrint
    {
        public MovieForPrint(Movie movie)
        {
            this.Title = movie.Title;
            this.Year = movie.Year;
            this.Length = movie.Length;
            this.Producer = movie.Producer.Name;
            this.Studio = movie.Studio.Name;
            this.Book = movie.Book.Title;
            this.Stars = string.Join(", ", movie.Stars.Select(star => star.FirstName + star.LastName));
            this.Genres = string.Join(", ", movie.Genres.Select(genre => genre.Name));
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public int Length { get; private set; }

        public string Producer { get; private set; }

        public string Studio { get; private set; }

        public string Book { get; private set; }

        public string Stars { get; private set; }

        public string Genres { get; private set; }
    }
}
