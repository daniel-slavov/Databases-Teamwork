using Moq;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Services;
using MoviesDatabase.Services.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Test.Services
{
    [TestFixture]
    public class MovieServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenRepositoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();

            Assert.Throws<ArgumentNullException>(
                () => new MovieService(null, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();

            Assert.Throws<ArgumentNullException>(
                () => new MovieService(movieRepositoryMock.Object, null, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenFactoryIsNull()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();

            Assert.Throws<ArgumentNullException>(
                () => new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, null, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenProducerServiceIsNull()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();

            Assert.Throws<ArgumentNullException>(
                () => new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, null,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenStudioServiceIsNull()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();

            Assert.Throws<ArgumentNullException>(
                () => new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object,
                producerServiceMock.Object, null, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenGenreServiceIsNull()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();

            Assert.Throws<ArgumentNullException>(
                () => new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object,
                producerServiceMock.Object, studioServiceMock.Object, null,
                bookServiceMock.Object, starServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenBookServiceIsNull()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var starServiceMock = new Mock<IStarService>();

            Assert.Throws<ArgumentNullException>(
                () => new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object,
                producerServiceMock.Object, studioServiceMock.Object, genreServiceMock.Object,
                null, starServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenStarServiceIsNull()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();

            Assert.Throws<ArgumentNullException>(
                () => new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object,
                producerServiceMock.Object, studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenValidParametersPassed()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();

            Assert.DoesNotThrow(
                () => new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object));
        }

        [Test]
        public void GetMovieByTitle_ShouldCallRepositoryEntities_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            movieService.GetMovieByTitle(title);

            movieRepositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [Test]
        public void GetMovieByTitle_ShouldReturnCorrectMovie_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var year = 2017;
            var length = 136;
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();

            var movie = new Movie(title, year, null, length, null, null, null, null, null);
            var list = new List<Movie>() { movie };
            var queryableMovies = list.AsQueryable();

            movieRepositoryMock.Setup(r => r.Entities).Returns(queryableMovies);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            var returnedMovie = movieService.GetMovieByTitle(title);

            Assert.AreSame(movie, returnedMovie);
        }

        [Test]
        public void GetMoviesByGenre_ShouldCallGenreService_WhenValidParametersPassed()
        {
            var genre = "Comedy";
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var genreMock = new Mock<Genre>();
            genreServiceMock.Setup(g => g.GetGenreBy(genre)).Returns(genreMock.Object);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            movieService.GetMoviesByGenre(genre);

            genreServiceMock.Verify(g => g.GetGenreBy(genre), Times.Once);
        }

        [Test]
        public void GetMoviesByGenre_ShouldReturnCorrectMovies_WhenValidParametersPassed()
        {
            var genre = "Comedy";
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var genreMock = new Mock<Genre>();
            genreServiceMock.Setup(s => s.GetGenreBy(genre)).Returns(genreMock.Object);
            var movies = new List<Movie>()
            {
                new Movie("Fast And Furious", 2001, null, 112, null, null, null, null, null),
                new Movie("Fast And Furious 2", 2002, null, 112, null, null, null, null, null),
            };
            genreMock.Setup(g => g.Movies).Returns(movies);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            var returnedMovies = movieService.GetMoviesByGenre(genre);

            Assert.AreSame(movies, returnedMovies);
        }

        [Test]
        public void GetMoviesByStar_ShouldCallStarService_WhenValidParametersPassed()
        {
            var starName = "Natalie Portman";
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var starMock = new Mock<Star>();
            starServiceMock.Setup(s => s.GetStarByName(It.IsAny<string>(), It.IsAny<string>())).Returns(starMock.Object);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
               studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            movieService.GetMoviesByStar(starName);

            starServiceMock.Verify(s => s.GetStarByName(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void GetMoviesByStar_ShouldReturnCorrectMovies_WhenValidParametersPassed()
        {
            var starName = "Natalie Portman";
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var starMock = new Mock<Star>();
            starServiceMock.Setup(s => s.GetStarByName(It.IsAny<string>(), It.IsAny<string>())).Returns(starMock.Object);
            var movies = new List<Movie>()
            {
                new Movie("Fast And Furious", 2001, null, 112, null, null, null, null, null),
                new Movie("Fast And Furious 2", 2002, null, 112, null, null, null, null, null),
            };
            starMock.Setup(g => g.Movies).Returns(movies);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            var returnedMovies = movieService.GetMoviesByStar(starName);

            Assert.AreSame(movies, returnedMovies);
        }

        [Test]
        public void GetAllMovies_ShouldCallRepository_WhenValidParametersPassed()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            movieService.GetAllMovies();

            movieRepositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [Test]
        public void GetAllMovies_ShouldReturnCorrectMovies_WhenValidParametersPassed()
        {
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var movies = new List<Movie>()
            {
                new Movie("Fast And Furious", 2001, null, 112, null, null, null, null, null),
                new Movie("Fast And Furious 2", 2002, null, 112, null, null, null, null, null),
            };
            var queryableMovies = movies.AsQueryable();
            movieRepositoryMock.Setup(r => r.Entities).Returns(queryableMovies);

            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            var allMovies = movieService.GetAllMovies();

            Assert.AreEqual(movies, allMovies);
        }

        [Test]
        public void DeleteMovie_ShouldCallRepositoryEntities_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var list = new List<Movie>() { new Movie(title, 2001, null, 113, null, null, null, null, null) };
            var queryableMovies = list.AsQueryable();
            movieRepositoryMock.Setup(r => r.Entities).Returns(queryableMovies);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            movieService.DeleteMovie(title);

            movieRepositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [Test]
        public void DeleteMovie_ShouldThrowNullReferenceException_WhenMovieIsNotFound()
        {
            var title = "Star Wars";
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var list = new List<Movie>();
            var queryableMovies = list.AsQueryable();
            movieRepositoryMock.Setup(r => r.Entities).Returns(queryableMovies);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
            studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            Assert.Throws<NullReferenceException>(() => movieService.DeleteMovie(title));
        }

        [Test]
        public void DeleteMovie_ShouldCalRepositoryDeleteMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var list = new List<Movie>() { new Movie(title, 2001, null, 113, null, null, null, null, null) };
            var queryableMovies = list.AsQueryable();
            movieRepositoryMock.Setup(r => r.Entities).Returns(queryableMovies);

            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            movieService.DeleteMovie(title);

            movieRepositoryMock.Verify(r => r.Delete(It.IsAny<Movie>()), Times.Once);
        }

        [Test]
        public void DeleteMovie_ShouldCalUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var list = new List<Movie>() { new Movie(title, 2001, null, 113, null, null, null, null, null) };
            var queryableMovies = list.AsQueryable();
            movieRepositoryMock.Setup(r => r.Entities).Returns(queryableMovies);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);

            movieService.DeleteMovie(title);

            unitOfWorkMock.Verify(r => r.Commit(), Times.Once);
        }
    }
}
