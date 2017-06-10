using System.ComponentModel.DataAnnotations;

namespace MoviesDatabase.Models
{
    public class Book
    {
        public Book()
        {

        }

        public Book(string title, string author, int? year)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
        }

        public int BookID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public int? Year { get; set; }
    }
}