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


        [Test]
        public void CreateMovie_ShouldCallGetGenreByMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var year = 2001;
            var length = 136;
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var genre = new Genre("Adventure");
            genreServiceMock.Setup(s => s.GetGenreBy(It.IsAny<string>())).Returns(genre);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            movieService.CreateMovie(title, year, null, length, null, null, null, genres, stars);

            genreServiceMock.Verify(s => s.GetGenreBy(It.IsAny<string>()), Times.Exactly(genres.Count));
        }

        [Test]
        public void CreateMovie_ShouldCallCreateGenreMethod_WhenGenreIsNotFound()
        {
            var title = "Star Wars";
            var year = 2001;
            var length = 136;
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            genreServiceMock.Setup(s => s.GetGenreBy("Adventure")).Returns((Genre)null);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            movieService.CreateMovie(title, year, null, length, null, null, null, genres, stars);

            genreServiceMock.Verify(s => s.CreateGenre(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void CreateMovie_ShouldCallGetStarByNameMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var year = 2001;
            var length = 136;
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var star = new Star("Harrison", "Ford", null, null);
            starServiceMock.Setup(s => s.GetStarByName(It.IsAny<string>(), It.IsAny<string>())).Returns(star);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            movieService.CreateMovie(title, year, null, length, null, null, null, genres, stars);

            starServiceMock.Verify(s => s.GetStarByName(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(stars.Count));
        }

        [Test]
        public void CreateMovie_ShouldCallCreateStarMethod_WhenStarIsNotFound()
        {
            var title = "Star Wars";
            var year = 2001;
            var length = 136;
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            starServiceMock.Setup(s => s.GetStarByName("Harrison", "Ford")).Returns((Star)null);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            movieService.CreateMovie(title, year, null, length, null, null, null, genres, stars);

            starServiceMock.Verify(s => s.CreateStar(It.IsAny<string>(), It.IsAny<string>(), null, null), Times.Exactly(1));
        }

        [Test]
        public void CreateMovie_ShouldCallGetProducerByMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var producer = "George Lucas";
            var year = 2001;
            var length = 136;
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
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };


            movieService.CreateMovie(title, year, null, length, producer, null, null, genres, stars);

            producerServiceMock.Verify(s => s.GetProducerBy(producer), Times.Once);
        }

        [Test]
        public void CreateMovie_ShouldCallCreateProducerMethod_WhenProducerIsNotFound()
        {
            var title = "Star Wars";
            var producer = "George Lucas";
            var year = 2001;
            var length = 136;
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            producerServiceMock.Setup(s => s.GetProducerBy(producer)).Returns((Producer)null);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            movieService.CreateMovie(title, year, null, length, producer, null, null, genres, stars);

            producerServiceMock.Verify(s => s.CreateProducer(producer), Times.Once);
        }

        [Test]
        public void CreateMovie_ShouldCallGetStudioByNameMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var studio = "Twentieth Century";
            var year = 2001;
            var length = 136;
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
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };


            movieService.CreateMovie(title, year, null, length, null, studio, null, genres, stars);

            studioServiceMock.Verify(s => s.GetStudioByName(studio), Times.Once);
        }

        [Test]
        public void CreateMovie_ShouldCallCreateStudioMethod_WhenStudioIsNotFound()
        {
            var title = "Star Wars";
            var studio = "Twentieth Century";
            var year = 2001;
            var length = 136;
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            studioServiceMock.Setup(s => s.GetStudioByName(studio)).Returns((Studio)null);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            movieService.CreateMovie(title, year, null, length, null, studio, null, genres, stars);

            studioServiceMock.Verify(s => s.CreateStudio(studio, null), Times.Once);
        }

        [Test]
        public void CreateMovie_ShouldCallGetBookByTitleMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var bookTitle = "some title";
            var year = 2001;
            var length = 136;
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
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };


            movieService.CreateMovie(title, year, null, length, null, null, bookTitle, genres, stars);

            bookServiceMock.Verify(s => s.GetBookByTitle(bookTitle), Times.Once);
        }

        [Test]
        public void CreateMovie_ShouldCallCreateBookMethod_WhenBookIsNotFound()
        {
            var title = "Star Wars";
            var bookTitle = "some title";
            var year = 2001;
            var length = 136;
            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            bookServiceMock.Setup(s => s.GetBookByTitle(bookTitle)).Returns((Book)null);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            movieService.CreateMovie(title, year, null, length, null, null, bookTitle, genres, stars);

            bookServiceMock.Verify(s => s.CreateBook(bookTitle, null, null), Times.Once);
        }

        [Test]
        public void CreateMovie_ShouldCallFactoryCreateMovieMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var year = 2001;
            var length = 136;
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
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            movieService.CreateMovie(title, year, null, length, null, null, null, genres, stars);

            movieFactoryMock.Verify(
                s => s.CreateMovie(title, year, null, length, null, null, null, It.IsAny<List<Genre>>(), It.IsAny<List<Star>>()), Times.Once);
        }

        [Test]
        public void CreateMovie_ShouldCallRepositoryAddMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var year = 2001;
            var length = 136;
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
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };
            
            movieService.CreateMovie(title, year, null, length, null, null, null, genres, stars);

            movieRepositoryMock.Verify(s => s.Add(It.IsAny<Movie>()), Times.Once);
        }

        [Test]
        public void CreateMovie_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var year = 2001;
            var length = 136;
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
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            movieService.CreateMovie(title, year, null, length, null, null, null, genres, stars);

            unitOfWorkMock.Verify(n => n.Commit(), Times.Once);
        }

        [Test]
        public void CreateMovie_ShouldReturnCorrectMovie_WhenValidParametersPassed()
        {
            var title = "Star Wars";
            var year = 2001;
            var length = 136;
            var genres = new List<string>()
            {
                "Adventure"
            };
            var stars = new List<string>()
            {
                "Harrison Ford"
            };

            var movieRepositoryMock = new Mock<IRepository<Movie>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var movieFactoryMock = new Mock<IMovieFactory>();
            var producerServiceMock = new Mock<IProducerService>();
            var studioServiceMock = new Mock<IStudioService>();
            var genreServiceMock = new Mock<IGenreService>();
            var bookServiceMock = new Mock<IBookService>();
            var starServiceMock = new Mock<IStarService>();
            var genresObjects = new List<Genre>()
            {
                new Genre("Adventure")
            };
            var starsObjects = new List<Star>()
            {
                new Star("Harrison", "Ford", null, null)
            };
            var producer = new Producer("George Lucas");
            producerServiceMock.Setup(s => s.CreateProducer("George Lucas")).Returns(producer);

            var book = new Book("Star Wars", null, null);
            bookServiceMock.Setup(s => s.CreateBook("Star Wars", null, null)).Returns(book);

            var studio = new Studio("Twentieth Century", null);
            studioServiceMock.Setup(s => s.CreateStudio("Twentieth Century", null)).Returns(studio);
            starServiceMock.Setup(s => s.GetStarByName("Harrison", "Ford")).Returns(starsObjects[0]);
            genreServiceMock.Setup(s => s.GetGenreBy("Adventure")).Returns(genresObjects[0]);

            var movie = new Movie(title, year, null, length, producer, studio, book, genresObjects, starsObjects);
            movieFactoryMock.Setup(f => f.CreateMovie(title, year, null, length, producer, studio, book, genresObjects, starsObjects)).Returns(movie);
            var movieService = new MovieService(movieRepositoryMock.Object, unitOfWorkMock.Object, movieFactoryMock.Object, producerServiceMock.Object,
                studioServiceMock.Object, genreServiceMock.Object, bookServiceMock.Object, starServiceMock.Object);


            var createdMovie = movieService.CreateMovie(title, year, null, length, "George Lucas", "Twentieth Century", "Star Wars", genres, stars);

            Assert.AreSame(movie, createdMovie);
        }
    }
}
