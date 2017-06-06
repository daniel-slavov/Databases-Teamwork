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
using System.Data.Entity;

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
                this.CreateMovie(movie.Title, movie.Year, movie.Description, movie.Length, movie.ProducerName,
                    movie.StudioName, movie.BookTitle, movie.Genres, movie.Stars);
            }
        }

        public Movie CreateMovie(string title, int year, string description, int length, string producerName, string studioName, string bookTitle, IEnumerable<string> genres, IEnumerable<string> stars)
        {
            var listOfGenres = new List<Genre>();
            foreach (var genreName in genres)
            {
                var genre = this.genreService.GetGenreBy(genreName);
                //Console.WriteLine(genre);
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

            var listOfStars = new List<Star>();
            foreach (var starName in stars)
            {
                var firstName = starName.Split(' ')[0];
                var lastName = starName.Split(' ')[1];
                var star = this.starService.GetStarByName(firstName, lastName);
                if (star == null)
                {
                    var newStar = this.starService.CreateStar(firstName, lastName, 0, null);
                    listOfStars.Add(newStar);
                }
                else
                {
                    listOfStars.Add(star);
                }
            }

            var producer = this.producerService.GetProducerBy(producerName);
            if (producer == null)
            {
                producer = this.producerService.CreateProducer(producerName);
            }

            var studio = this.studioService.GetStudioBy(studioName);
            if (studio == null)
            {
                studio = this.studioService.CreateStudio(studioName, null);
            }

            var book = this.bookService.GetBookBy(bookTitle);
            if (book == null)
            {
                book = this.bookService.CreateBook(bookTitle, null, 0);
            }

            var movie = this.movieFactory.CreateMovie(title, year, description, length, producer, studio, book, listOfGenres, listOfStars);
            this.movieRepository.Add(movie);

            return movie;
        }

        public Movie GetMovieBy(string title)
        {
            var movie = this.movieRepository.Entities
                .FirstOrDefault(m => m.Title == title);

            return movie;
        }

        public IEnumerable<Movie> GetMoviesByGenre(string genreName)
        {
            var genre = this.genreService.GetGenreBy(genreName);
            var movies = genre.Movies;

            return movies;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var movies = this.movieRepository.Entities.ToList();
            return movies;
        }

        public void UpdateMovie(Movie movie)
        {
            this.movieRepository.Update(movie);
        }

        public void DeleteMovie(string title)
        {
            var movie = this.movieRepository.Entities
                .FirstOrDefault(m => m.Title == title);

            this.movieRepository.Delete(movie);
        }
    }
}