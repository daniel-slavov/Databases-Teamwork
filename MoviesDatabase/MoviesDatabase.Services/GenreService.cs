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
        private const string filePath = "...";
        private readonly IRepository<Genre> genreRepository;
        private readonly IJSONParser jsonParser;
        private readonly IGenreFactory genreFactory;

        public GenreService(IRepository<Genre> genreRepository, IJSONParser jsonParser, IGenreFactory genreFactory)
        {
            if (genreRepository == null)
            {
                throw new ArgumentNullException("Genre repository cannot be null!");
            }

            if (jsonParser == null)
            {
                throw new ArgumentNullException("Json parser cannot be null!");
            }

            if (genreFactory == null)
            {
                throw new ArgumentNullException("Genre factory cannot be null!");
            }

            this.genreRepository = genreRepository;
            this.jsonParser = jsonParser;
            this.genreFactory = genreFactory;
        }

        public void AddGenres()
        {
            var genres = this.jsonParser.Parse<Genre>(filePath);
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
    }
}
