using MoviesDatabase.Models.Contracts;

namespace MoviesDatabase.Models
{
    public class Studio : IModel
    {
        public Studio()
        {

        }

        public int StudioID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}