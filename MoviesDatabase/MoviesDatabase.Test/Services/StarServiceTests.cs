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
    public class StarServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenRepositoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new StarService(null, unitOfWorkMock.Object, starFactoryMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var starFactoryMock = new Mock<IStarFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new StarService(starRepositoryMock.Object, null, starFactoryMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenFactoryIsNull()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(
                () => new StarService(starRepositoryMock.Object, unitOfWorkMock.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenValidParametersPassed()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();


            Assert.DoesNotThrow(
                () => new StarService(starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object));
        }

        [Test]
        public void AddStars_ShouldCallRepositoryAddMethod_WhenValidListIsPassed()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);
            var stars = new List<Star>
            {
                new Star("Natalie", "Portman", null, null),
                new Star("Tom", "Cruise", null, null)
            };

            starService.AddStars(stars);

            starRepositoryMock.Verify(r => r.Add(It.IsAny<Star>()), Times.Exactly(stars.Count));
        }

        [Test]
        public void AddStars_ShouldCallUnitOfWorkCommitMethod_WhenValidListIsPassed()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);
            var stars = new List<Star>
            {
                new Star("Natalie", "Portman", null, null),
                new Star("Tom", "Cruise", null, null)
            };

            starService.AddStars(stars);

            unitOfWorkMock.Verify(n => n.Commit(), Times.Once);
        }

        [Test]
        public void CreateStar_ShouldCallFactoryCreateStarMethod_WhenValidParametersPassed()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            var firstName = "Natalie";
            var lastName = "J.Portman";

            starService.CreateStar(firstName, lastName, null, null);

            starFactoryMock.Verify(f => f.CreateStar(firstName, lastName, null, null), Times.Once);
        }

        [Test]
        public void CreatStar_ShouldCallRepositoryAddMethod_WhenValidParametersPassed()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            var firstName = "Natalie";
            var lastName = "Portman";
            var star = new Star(firstName, lastName, null, null);
            starFactoryMock.Setup(f => f.CreateStar(firstName, lastName, null, null)).Returns(star);

            starService.CreateStar(firstName, lastName, null, null);

            starRepositoryMock.Verify(r => r.Add(star), Times.Once);
        }

        [Test]
        public void CreateStar_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);
            var firstName = "Natalie";
            var lastName = "Portman";

            starService.CreateStar(firstName, lastName, null, null);

            unitOfWorkMock.Verify(n => n.Commit(), Times.Once);
        }

        [Test]
        public void CreateStar_ShouldReturnCorrectBook_WhenValidParametersPassed()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);
            var firstName = "Natalie";
            var lastName = "Portman";
            var star = new Star(firstName, lastName, null, null);

            starFactoryMock.Setup(f => f.CreateStar(firstName, lastName, null, null)).Returns(star);

            var returnedStar = starService.CreateStar(firstName, lastName, null, null);

            Assert.AreSame(star, returnedStar);
        }

        [Test]
        public void GetStarByName_ShouldCallRepository_WhenValidParametersPassed()
        {
            var firstName = "Natalie";
            var lastName = "Portman";
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            starService.GetStarByName(firstName, lastName);

            starRepositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [Test]
        public void GetStarByName_ShouldReturnCorrectStar_WhenValidParametersPassed()
        {
            var firstName = "Natalie";
            var lastName = "Portman";
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();

            var star = new Star(firstName, lastName, null, null);
            var list = new List<Star>() { star };
            var queryableStars = list.AsQueryable();

            starRepositoryMock.Setup(r => r.Entities).Returns(queryableStars);
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            var returnedStar = starService.GetStarByName(firstName, lastName);

            Assert.AreSame(star, returnedStar);
        }

        [Test]
        public void UpdateStar_ShouldCallRepositoryAddMethod_WhenValidParametersPassed()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var starMock = new Mock<Star>();
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            starService.UpdateStar(starMock.Object);

            starRepositoryMock.Verify(r => r.Update(starMock.Object), Times.Once);
        }

        [Test]
        public void UpdateStar_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var starMock = new Mock<Star>();
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            starService.UpdateStar(starMock.Object);

            unitOfWorkMock.Verify(n => n.Commit(), Times.Once);
        }

        [Test]
        public void DeleteStar_ShouldCallRepositoryEntities_WhenValidParametersPassed()
        {
            var firstName = "Natalie";
            var lastName = "Portman";
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var list = new List<Star>() { new Star(firstName, lastName, null, null) };
            var queryableStars = list.AsQueryable();
            starRepositoryMock.Setup(r => r.Entities).Returns(queryableStars);
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            starService.DeleteStar(firstName, lastName);

            starRepositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [Test]
        public void DeleteStar_ShouldThrowArgumentNullException_WhenBookIsNotFound()
        {
            var firstName = "Natalie";
            var lastName = "Portman";
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var list = new List<Star>();
            var queryableStars = list.AsQueryable();
            starRepositoryMock.Setup(r => r.Entities).Returns(queryableStars);
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            Assert.Throws<NullReferenceException>(() => starService.DeleteStar(firstName, lastName));
        }

        [Test]
        public void DeleteStar_ShouldCallRepositoryDeleteMethod_WhenValidParametersPassed()
        {
            var firstName = "Natalie";
            var lastName = "Portman";
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var star = new Star(firstName,lastName, null, null);
            var list = new List<Star>() { star };
            var queryableStars = list.AsQueryable();
            starRepositoryMock.Setup(r => r.Entities).Returns(queryableStars);
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            starService.DeleteStar(firstName, lastName);

            starRepositoryMock.Verify(r => r.Delete(star), Times.Once);
        }

        [Test]
        public void DeleteBook_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var firstName = "Natalie";
            var lastName = "Portman";
            var starRepositoryMock = new Mock<IRepository<Star>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var starFactoryMock = new Mock<IStarFactory>();
            var star = new Star(firstName, lastName, null, null);
            var list = new List<Star>() { star };
            var queryableStars = list.AsQueryable();
            starRepositoryMock.Setup(r => r.Entities).Returns(queryableStars);
            var starService = new StarService(
                starRepositoryMock.Object, unitOfWorkMock.Object, starFactoryMock.Object);

            starService.DeleteStar(firstName, lastName);

            unitOfWorkMock.Verify(r => r.Commit(), Times.Once);
        }

    }
}
