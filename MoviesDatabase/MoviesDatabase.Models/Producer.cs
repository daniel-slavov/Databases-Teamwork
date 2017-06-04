using MoviesDatabase.Models.Contracts;

namespace MoviesDatabase.Models
{
    public class Producer : IModel
    {
        public Producer()
        {

        }

        public Producer(string name)
        {
            this.Name = name;
        }

        public int ProducerID { get; set; }

        public string Name { get; set; }
    }
}