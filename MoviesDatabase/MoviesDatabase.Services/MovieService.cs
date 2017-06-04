using System;
using System.Collections.Generic;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Models.Contracts;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Parsers.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.Services
{
    public class MovieService : IMovieService
    {
        private const string filePath = "...";
        private readonly IRepository<Movie> movieRepository;
        private readonly IJSONParser jsonParser;
        private readonly IMovieFactory movieFactory;

        public MovieService(IRepository<Movie> movieRepository, IJSONParser jsonParser, IMovieFactory movieFactory)
        {
            if (movieRepository == null)
            {
                throw new ArgumentNullException("Movie repository cannot be null!");
            }

            if (jsonParser == null)
            {
                throw new ArgumentNullException("Json parser cannot be null!");
            }

            if (movieFactory == null)
            {
                throw new ArgumentNullException("Movie factory cannot be null!");
            }

            this.movieRepository = movieRepository;
            this.jsonParser = jsonParser;
            this.movieFactory = movieFactory;
        }

        public void AddMovies()
        {
            var movies = this.jsonParser.Parse<MovieModel>(filePath);


        }

        public Movie CreateMovie(string title, int year, string description, int length, Producer producer, Studio studio, Book book)
        {
            var movie = this.movieFactory.CreateMovie(title, year, description, length, producer, studio, book);
            this.movieRepository.Add(movie);

            return movie;
        }
    }
}
