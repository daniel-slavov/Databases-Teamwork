using Moq;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Test.Services
{
    [TestFixture]
    public class GenreServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenRepositoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            Assert.Throws<ArgumentNullException>(
                () => new GenreService(null, unitOfWorkMock.Object, genreFactoryMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            Assert.Throws<ArgumentNullException>(
                () => new GenreService(genreRepositoryMock.Object, null, genreFactoryMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenFactoryIsNull()
        {
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Assert.Throws<ArgumentNullException>(
                () => new GenreService(genreRepositoryMock.Object, unitOfWorkMock.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenValidParametersPassed()
        {
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            Assert.DoesNotThrow(
                () => new GenreService(genreRepositoryMock.Object, unitOfWorkMock.Object, genreFactoryMock.Object));
        }

        [Test]
        public void AddGenres_ShouldCallRepositoryAddMethod_WhenValidParametersPassed()
        {
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            var genreService = new GenreService(
                genreRepositoryMock.Object, unitOfWorkMock.Object, genreFactoryMock.Object);
            var genres = new List<Genre>()
            {
                new Genre("Comedy"),
                new Genre("Adventure")
            };

            genreService.AddGenres(genres);

            genreRepositoryMock.Verify(r => r.Add(It.IsAny<Genre>()), Times.Exactly(genres.Count));
        }

        [Test]
        public void AddGenres_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            var genreService = new GenreService(
                genreRepositoryMock.Object, unitOfWorkMock.Object, genreFactoryMock.Object);

            var genres = new List<Genre>()
            {
                new Genre("Comedy"),
                new Genre("Adventure")
            };

            genreService.AddGenres(genres);

            unitOfWorkMock.Verify(n => n.Commit(), Times.Once);
        }

        [Test]
        public void CreateGenre_ShouldCallFactoryCreateGenreMethod_WhenValidParametersPassed()
        {
            var name = "Comedy";
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            var genreService = new GenreService(
                genreRepositoryMock.Object, unitOfWorkMock.Object, genreFactoryMock.Object);

            genreService.CreateGenre(name);

            genreFactoryMock.Verify(f => f.CreateGenre(name), Times.Once);
        }

        [Test]
        public void CreateGenre_ShouldCallRepositoryAddMethod_WhenValidParametersPassed()
        {
            var name = "Comedy";
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            var genreService = new GenreService(
                genreRepositoryMock.Object, unitOfWorkMock.Object, genreFactoryMock.Object);

            genreService.CreateGenre(name);

            genreRepositoryMock.Verify(r => r.Add(It.IsAny<Genre>()), Times.Once);
        }

        [Test]
        public void CreateGenre_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var name = "Comedy";
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            var genreService = new GenreService(
                genreRepositoryMock.Object, unitOfWorkMock.Object, genreFactoryMock.Object);

            genreService.CreateGenre(name);

            unitOfWorkMock.Verify(u => u.Commit(), Times.Once);
        }

        [Test]
        public void CreateGenre_ShouldReturnCorrectGenre_WhenValidParametersPassed()
        {
            var name = "Comedy";
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            var genre = new Genre(name);
            genreFactoryMock.Setup(f => f.CreateGenre(name)).Returns(genre);
            var genreService = new GenreService(
                genreRepositoryMock.Object, unitOfWorkMock.Object, genreFactoryMock.Object);

            var returnedGenre = genreService.CreateGenre(name);

            Assert.AreSame(genre, returnedGenre);
        }

        [Test]
        public void GetGenreBy_ShouldCallRepository_WhenValidParametersPassed()
        {
            var name = "Comedy";
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            var genreService = new GenreService(
                genreRepositoryMock.Object, unitOfWorkMock.Object, genreFactoryMock.Object);

            genreService.GetGenreBy(name);

            genreRepositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [Test]
        public void GetGenreBy_ShouldReturnCorrectGenre_WhenValidParametersPassed()
        {
            var name = "Comedy";
            var genreRepositoryMock = new Mock<IRepository<Genre>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var genreFactoryMock = new Mock<IGenreFactory>();
            var genre = new Genre(name);
            var list = new List<Genre>() { genre };
            var queryableGenres = list.AsQueryable();

            genreRepositoryMock.Setup(r => r.Entities).Returns(queryableGenres);
            var genreService = new GenreService(
                genreRepositoryMock.Object, unitOfWorkMock.Object, genreFactoryMock.Object);

            var returnedGenre = genreService.GetGenreBy(name);

            Assert.AreSame(genre, returnedGenre);
        }
    }
}
