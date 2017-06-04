using MoviesDatabase.Models.Contracts;

namespace MoviesDatabase.Models
{
    public class Studio : IModel
    {
        public Studio()
        {

        }

        public Studio(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

        public int StudioID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}