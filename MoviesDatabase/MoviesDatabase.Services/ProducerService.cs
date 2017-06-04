using System;
using System.Collections.Generic;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.Services
{
    public class ProducerService : IProducerService
    {
        private const string filePath = "...";
        private readonly IRepository<Producer> producerRepository;
        private readonly IJSONParser jsonParser;
        private readonly IProducerFactory producerFactory;

        public ProducerService(IRepository<Producer> producerRepository, IJSONParser jsonParser, IProducerFactory producerFactory)
        {
            if (producerRepository == null)
            {
                throw new ArgumentNullException("Producer repository cannot be null!");
            }

            if (jsonParser == null)
            {
                throw new ArgumentNullException("Json parser cannot be null!");
            }

            if (producerFactory == null)
            {
                throw new ArgumentNullException("Producer factory cannot be null!");
            }

            this.producerRepository = producerRepository;
            this.jsonParser = jsonParser;
            this.producerFactory = producerFactory;
        }

        public void AddProducers()
        {
            var producers = this.jsonParser.Parse<Producer>(filePath);
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
    }
}
