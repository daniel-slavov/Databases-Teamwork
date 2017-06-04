using MoviesDatabase.Models.Contracts;

namespace MoviesDatabase.Models
{
    public class Book : IModel
    {
        public Book()
        {

        }

        public Book(string title, string author, int year)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
        }

        public int BookID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }
    }
}