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
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> genreRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenreFactory genreFactory;

        public GenreService(IRepository<Genre> genreRepository, IUnitOfWork unitOfWork, IGenreFactory genreFactory)
        {
            if (genreRepository == null)
            {
                throw new ArgumentNullException("Genre repository cannot be null!");
            }

            if (genreFactory == null)
            {
                throw new ArgumentNullException("Genre factory cannot be null!");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null!");
            }

            this.genreRepository = genreRepository;
            this.unitOfWork = unitOfWork;
            this.genreFactory = genreFactory;
        }

        public void AddGenres(IList<Genre> genres)
        {
            foreach (var genre in genres)
            {
                this.genreRepository.Add(genre);
            }

            this.unitOfWork.Commit();
        }

        public Genre CreateGenre(string name)
        {
            var genre = this.genreFactory.CreateGenre(name);
            this.genreRepository.Add(genre);
            this.unitOfWork.Commit();

            return genre;
        }

        public Genre GetGenreBy(string name)
        {
            var genre = this.genreRepository.Entities.Include(g => g.Movies)
                .FirstOrDefault(g => g.Name == name);

            return genre;
        }
    }
}
