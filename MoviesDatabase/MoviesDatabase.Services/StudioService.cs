using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.Services
{
    public class StudioService : IStudioService
    {
        private const string filePath = "...";
        private readonly IRepository<Studio> studioRepository;
        private readonly IJSONParser jsonParser;
        private readonly IStudioFactory studioFactory;

        public StudioService(IRepository<Studio> studioRepository, IJSONParser jsonParser, IStudioFactory studioFactory)
        {
            if (studioRepository == null)
            {
                throw new ArgumentNullException("Studio repository cannot be null!");
            }

            if (jsonParser == null)
            {
                throw new ArgumentNullException("Json parser cannot be null!");
            }

            if (studioFactory == null)
            {
                throw new ArgumentNullException("Studio factory cannot be null!");
            }

            this.studioRepository = studioRepository;
            this.jsonParser = jsonParser;
            this.studioFactory = studioFactory;
        }

        public void AddStudios()
        {
            var studios = this.jsonParser.Parse<Studio>(filePath);
            foreach (var studio in studios)
            {
                this.studioRepository.Add(studio);
            }
        }

        public Studio CreateStudio(string name, string address)
        {
            var studio = this.studioFactory.CreateStudio(name, address);
            this.studioRepository.Add(studio);

            return studio;
        }

        public Studio GetStudioBy(string name)
        {
            var studio = this.studioRepository.Entities
                .FirstOrDefault(s => s.Name == name);

            return studio;
        }
    }
}
