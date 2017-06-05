using System;
using System.Collections.Generic;
using System.Linq;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IRepository<Producer> producerRepository;
        private readonly IProducerFactory producerFactory;

        public ProducerService(IRepository<Producer> producerRepository, IProducerFactory producerFactory)
        {
            if (producerRepository == null)
            {
                throw new ArgumentNullException("Producer repository cannot be null!");
            }

            if (producerFactory == null)
            {
                throw new ArgumentNullException("Producer factory cannot be null!");
            }

            this.producerRepository = producerRepository;
            this.producerFactory = producerFactory;
        }

        public void AddProducers(IList<Producer> producers)
        {
            foreach (var producer in producers)
            {
                this.producerRepository.Add(producer);
            }
        }

        public Producer CreateProducer(string name)
        {
            var producer = this.producerFactory.CreateProducer(name);
            this.producerRepository.Add(producer);

            return producer;
        }

        public Producer GetProducerBy(string name)
        {
            var producer = this.producerRepository.Entities
                .FirstOrDefault(p => p.Name == name);

            return producer;
        }
    }
}
