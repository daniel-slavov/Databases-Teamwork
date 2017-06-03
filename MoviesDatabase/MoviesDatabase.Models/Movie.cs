using System.Collections.Generic;
using MoviesDatabase.Models.Contracts;

namespace MoviesDatabase.Models
{
    public class Movie : IModel
    {
        public Movie()
        {
            this.Stars = new HashSet<Star>();
            this.Genres = new HashSet<Genre>();
        }

        public int MovieID { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public int Length { get; set; }

        public int ProducerID { get; set; }

        public virtual Producer Producer { get; set; }

        public int StudioID { get; set; }

        public virtual Studio Studio { get; set; }

        public int BookID { get; set; }

        public virtual Book Book { get; set; }

        public ICollection<Star> Stars { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
