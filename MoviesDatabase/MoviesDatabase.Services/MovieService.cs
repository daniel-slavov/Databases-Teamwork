using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IRepository<Movie> movieRepository;
        private readonly IMovieFactory movieFactory;
        private readonly IProducerService producerService;
        private readonly IStudioService studioService;
        private readonly IGenreService genreService;
        private readonly IBookService bookService;
        private readonly IStarService starService;

        public MovieService(IRepository<Movie> movieRepository, IMovieFactory movieFactory, 
            IProducerService producerService, IStudioService studioService, IGenreService genreService, 
            IBookService bookService, IStarService starService)
        {
            if (movieRepository == null)
            {
                throw new ArgumentNullException("Movie repository cannot be null!");
            }

            if (movieFactory == null)
            {
                throw new ArgumentNullException("Movie factory cannot be null!");
            }

            if (producerService == null)
            {
                throw new ArgumentNullException("Producer service cannot be null!");
            }

            if (studioService == null)
            {
                throw new ArgumentNullException("Studio service cannot be null!");
            }

            if (genreService == null)
            {
                throw new ArgumentNullException("Genre service cannot be null!");
            }

            if (bookService == null)
            {
                throw new ArgumentNullException("Book service cannot be null!");
            }

            if (starService == null)
            {
                throw new ArgumentNullException("Star service cannot be null!");
            }

            this.movieRepository = movieRepository;
            this.movieFactory = movieFactory;
            this.producerService = producerService;
            this.studioService = studioService;
            this.genreService = genreService;
            this.bookService = bookService;
            this.starService = starService;
        }

        public void AddMovies(IList<MovieModel> movies)
        {
            foreach (var movie in movies)
            {
                var listOfGenres = new List<Genre>();
                foreach (var genreName in movie.Genres)
                {
                    var genre = this.genreService.GetGenreBy(genreName);
                    if (genre == null)
                    {
                        var newGenre = this.genreService.CreateGenre(genreName);
                        listOfGenres.Add(newGenre);
                    }
                    else
                    {
                        listOfGenres.Add(genre);
                    }
                }

                var producer = this.producerService.GetProducerBy(movie.ProducerName);
                if (producer == null)
                {
                    producer = this.producerService.CreateProducer(movie.ProducerName);
                }

                var studio = this.studioService.GetStudioBy(movie.StudioName);
                if (studio == null)
                {
                    studio = this.studioService.CreateStudio(movie.StudioName, null);
                }

                var book = this.bookService.GetBookBy(movie.BookTitle);
                if (book == null)
                {
                    book = this.bookService.CreateBook(movie.BookTitle, null, 0);
                }

                this.movieFactory.CreateMovie(movie.Title, movie.Year, movie.Description, movie.Length, producer,
                    studio, book);
            }
        }

        public Movie CreateMovie(string title, int year, string description, int length, Producer producer, Studio studio, Book book)
        {
            var movie = this.movieFactory.CreateMovie(title, year, description, length, producer, studio, book);
            this.movieRepository.Add(movie);

            return movie;
        }

        public Movie GetMovieBy(string title)
        {
            var movie = this.movieRepository.Entities
                .FirstOrDefault(m => m.Title == title);

            return movie;
        }
    }
}
