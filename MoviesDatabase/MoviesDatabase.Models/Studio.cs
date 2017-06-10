using System.ComponentModel.DataAnnotations;

namespace MoviesDatabase.Models
{
    public class Studio
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

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}