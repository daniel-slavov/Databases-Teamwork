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
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> genreRepository;
        private readonly IGenreFactory genreFactory;

        public GenreService(IRepository<Genre> genreRepository, IGenreFactory genreFactory)
        {
            if (genreRepository == null)
            {
                throw new ArgumentNullException("Genre repository cannot be null!");
            }

            if (genreFactory == null)
            {
                throw new ArgumentNullException("Genre factory cannot be null!");
            }

            this.genreRepository = genreRepository;
            this.genreFactory = genreFactory;
        }

        public void AddGenres(IList<Genre> genres)
        {
            foreach (var genre in genres)
            {
                this.genreRepository.Add(genre);
            }
        }

        public Genre CreateGenre(string name)
        {
            var genre = this.genreFactory.CreateGenre(name);
            this.genreRepository.Add(genre);

            return genre;
        }

        public Genre GetGenreBy(string name)
        {
            var genre = this.genreRepository.Entities
                .FirstOrDefault(g => g.Name == name);

            return genre;
        }
    }
}
