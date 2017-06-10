using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesDatabase.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Stars = new HashSet<Star>();
            this.Genres = new HashSet<Genre>();
        }

        public Movie(string title, int year, string description, int length, Producer producer, Studio studio,
            Book book, ICollection<Genre> genres, ICollection<Star> stars) : this()
        {
            this.Title = title;
            this.Year = year;
            this.Description = description;
            this.Length = length;
            this.Producer = producer;
            this.Studio = studio;
            this.Book = book;
            this.Genres = genres;
            this.Stars = stars;
        }

        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public string Description { get; set; }

        public int Length { get; set; }

        public int? ProducerID { get; set; }

        public virtual Producer Producer { get; set; }

        public int? StudioID { get; set; }

        public virtual Studio Studio { get; set; }

        public int? BookID { get; set; }

        public virtual Book Book { get; set; }

        public ICollection<Star> Stars { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
