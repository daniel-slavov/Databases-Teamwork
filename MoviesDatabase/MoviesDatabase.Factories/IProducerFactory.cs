using MoviesDatabase.Models;

namespace MoviesDatabase.Factories
{
    public interface IProducerFactory
    {
        Producer CreateProducer(string name);
    }
}
