using System.ComponentModel.DataAnnotations;

namespace MoviesDatabase.Models
{
    public class Producer
    {
        public Producer()
        {

        }

        public Producer(string name)
        {
            this.Name = name;
        }

        public int ProducerID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}