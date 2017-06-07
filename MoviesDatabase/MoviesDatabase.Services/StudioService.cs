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
        private readonly IRepository<Studio> studioRepository;
        private readonly IStudioFactory studioFactory;

        public StudioService(IRepository<Studio> studioRepository, IStudioFactory studioFactory)
        {
            if (studioRepository == null)
            {
                throw new ArgumentNullException("Studio repository cannot be null!");
            }

            if (studioFactory == null)
            {
                throw new ArgumentNullException("Studio factory cannot be null!");
            }

            this.studioRepository = studioRepository;
            this.studioFactory = studioFactory;
        }

        public void AddStudios(IList<Studio> studios)
        {
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

        public Studio GetStudioByName(string name)
        {
            var studio = this.studioRepository.Entities
                .FirstOrDefault(s => s.Name == name);

            return studio;
        }

        public void UpdateStudio(Studio studio)
        {
			throw new NotImplementedException();
		}

		public void DeleteStudio(string name)
		{
			throw new NotImplementedException();
		}
    }
}
