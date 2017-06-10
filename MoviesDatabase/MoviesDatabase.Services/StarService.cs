using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.Services
{
    public class StarService : IStarService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Star> starRepository;
        private readonly IStarFactory starFactory;

        public StarService(IRepository<Star> starRepository, IUnitOfWork unitOfWork, IStarFactory starFactory)
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
            this.unitOfWork = unitOfWork;
            this.starFactory = starFactory;
        }

        public void AddStars(IList<Star> stars)
        {
            foreach (var star in stars)
            {
                this.starRepository.Add(star);
            }

            this.unitOfWork.Commit();
        }

        public Star CreateStar(string firstName, string lastName, int? age, string address)
        {
            var star = this.starFactory.CreateStar(firstName, lastName, age, address);
            this.starRepository.Add(star);
            this.unitOfWork.Commit();

            return star;
        }

        public Star GetStarByName(string firstName, string lastName)
        {
            var star = this.starRepository.Entities
                .Include(s => s.Movies)
                .FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            return star;
        }

        public IEnumerable<Movie> GetAllMoviesOfStar(string firstName, string lastName)
        {
            var star = this.GetStarByName(firstName, lastName);
            var movies = star.Movies;

            return movies;
        }

        public void UpdateStar(Star star)
        {
            this.starRepository.Update(star);
            this.unitOfWork.Commit();
        }

        public void DeleteStar(string firstName, string lastName)
        {
            var star = this.GetStarByName(firstName, lastName);
            if (star == null)
            {
                throw new NullReferenceException("There is not star with these names.");
            }

            this.starRepository.Delete(star);
            this.unitOfWork.Commit();
        }
    }
}
