using System.Collections.Generic;
using MoviesDatabase.Models.Contracts;

namespace MoviesDatabase.Models
{
    public class Genre : IModel
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int GenreID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
