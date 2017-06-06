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
    public class StarService : IStarService
    {
        private readonly IRepository<Star> starRepository;
        private readonly IStarFactory starFactory;

        public StarService(IRepository<Star> starRepository, IStarFactory starFactory)
        {
            if (starRepository == null)
            {
                throw new ArgumentNullException("Star repository cannot be null!");
            }

            if (starFactory == null)
            {
                throw new ArgumentNullException("Star factory cannot be null!");
            }

            this.starRepository = starRepository;
            this.starFactory = starFactory;
        }

        public void AddStars(IList<Star> stars)
        {
            foreach (var star in stars)
            {
                this.starRepository.Add(star);
            }
        }

        public Star CreateStar(string firstName, string lastName, int age, string address)
        {
            var star = this.starFactory.CreateStar(firstName, lastName, age, address);
            this.starRepository.Add(star);

            return star;
        }

        public Star GetStarByName(string firstName, string lastName)
        {
            var star = this.starRepository.Entities
                .FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            return star;
        }
    }
}
