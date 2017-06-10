using System.Collections.Generic;

namespace MoviesDatabase.Parsers.Models
{
    public class MovieModel
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public int Length { get; set; }

        public string ProducerName { get; set; }

        public string StudioName { get; set; }

        public string BookTitle { get; set; }

        public ICollection<string> Stars { get; set; }

        public ICollection<string> Genres { get; set; }
    }
}
