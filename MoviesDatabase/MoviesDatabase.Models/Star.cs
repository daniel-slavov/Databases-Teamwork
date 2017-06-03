using System.Collections.Generic;

namespace MoviesDatabase.Models
{
    public class Star
    {
        public Star()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int StarID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}