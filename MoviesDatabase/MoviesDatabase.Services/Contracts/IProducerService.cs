using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
