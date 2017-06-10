using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IProducerService
    {
        void AddProducers(IList<Producer> producers);

        Producer CreateProducer(string name);

        Producer GetProducerBy(string name);
    }
}
