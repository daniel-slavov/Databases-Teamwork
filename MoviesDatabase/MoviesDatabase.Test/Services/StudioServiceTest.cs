using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using NUnit.Framework;
using MoviesDatabase.Services;
using MoviesDatabase.Models;

namespace MoviesDatabase.Test.Services
{
    [TestFixture]
    public class StudioServiceTest
    {
        [Test]
        public void Contstructor_ShouldThrowArgumentNullException_WhenRepositoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new StudioService(null, unitOfWorkMock.Object, factoryMock.Object));
        }

        [Test]
        public void Contstructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var factoryMock = new Mock<IStudioFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new StudioService(repositoryMock.Object, null, factoryMock.Object));
        }

        [Test]
        public void Contstructor_ShouldThrowArgumentNullException_WhenFactoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Studio>>();

            Assert.Throws<ArgumentNullException>(
                () => new StudioService(repositoryMock.Object, unitOfWorkMock.Object, null));
        }

        [Test]
        public void Contstructor_ShouldNotThrowException_WhenArgumentsAreCorrect()
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();

            Assert.DoesNotThrow(
                () => new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object));
        }

        [TestCase("Studio", "Street")]
        public void CreateStudio_ShouldCallFactory_WhenParametersAreCorrect(string name, string address)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();

            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            service.CreateStudio(name, address);

            factoryMock.Verify(f => f.CreateStudio(name, address), Times.Once);
        }

        [TestCase("Studio", "Street")]
        public void CreateStudio_ShouldCallAddMethodOfRepository_WhenParametersAreCorrect(string name, string address)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();
            var studioMock = new Mock<Studio>();

            factoryMock.Setup(f => f.CreateStudio(name, address)).Returns(studioMock.Object);
            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            service.CreateStudio(name, address);

            repositoryMock.Verify(f => f.Add(studioMock.Object), Times.Once);
        }

        [TestCase("Studio", "Street")]
        public void CreateStudio_ShouldCallCommitMethodOfUnitOfWork_WhenParametersAreCorrect(string name, string address)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();

            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            service.CreateStudio(name, address);

            unitOfWorkMock.Verify(f => f.Commit(), Times.Once);
        }

        [TestCase("Studio", "Street")]
        public void CreateStudio_ShouldReturnTheSameStudio_WhenParametersAreCorrect(string name, string address)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();
            var studioMock = new Mock<Studio>();
            factoryMock.Setup(f => f.CreateStudio(name, address)).Returns(studioMock.Object);

            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            var result = service.CreateStudio(name, address);

            Assert.AreSame(studioMock.Object, result);
        }

        [TestCase("Studio")]
        public void GetStudioByName_ShouldCallRepository_WhenParametersAreCorrect(string name)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();

            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            service.GetStudioByName(name);

            repositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [TestCase("Studio")]
        public void GetStudioByName_ShouldReturnCorrectStudio_WhenParametersAreCorrect(string name)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();
            var listOfStudios = new List<Studio>();
            var studio = new Studio(name, null);
            listOfStudios.Add(studio);
            repositoryMock.Setup(r => r.Entities).Returns(listOfStudios.AsQueryable);

            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            var result = service.GetStudioByName(name);

            Assert.AreSame(studio, result);
        }

        [Test]
        public void UpdateStudio_ShouldCallRepository_WhenParametersAreCorrect()
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();
            var studioMock = new Mock<Studio>();
            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            service.UpdateStudio(studioMock.Object);

            repositoryMock.Verify(r => r.Update(studioMock.Object), Times.Once);
        }

        [Test]
        public void UpdateStudio_ShouldCallUnitOfWork_WhenParametersAreCorrect()
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();
            var studioMock = new Mock<Studio>();
            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            service.UpdateStudio(studioMock.Object);

            unitOfWorkMock.Verify(r => r.Commit(), Times.Once);
        }

        [TestCase("Studio")]
        public void DeleteStudio_ShouldCallEntitiesOfReository_WhenParametersAreCorrect(string name)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();

            var listOfStudios = new List<Studio>();

            listOfStudios.Add(new Studio(name, null));

            repositoryMock.Setup(r => r.Entities).Returns(listOfStudios.AsQueryable<Studio>);
            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            service.DeleteStudio(name);

            repositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [TestCase("Studio")]
        public void DeleteStudio_ShouldThrowException_WhenNoStudioIsFound(string name)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();

            var listOfStudios = new List<Studio>();

            repositoryMock.Setup(r => r.Entities).Returns(listOfStudios.AsQueryable<Studio>);
            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);

            Assert.Throws<NullReferenceException>(() => service.DeleteStudio(name));
        }

        [TestCase("Studio")]
        public void DeleteStudio_ShouldCallDeleteOfReository_WhenStudioIsFound(string name)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();
            var studio = new Studio(name, null);
            var listOfStudios = new List<Studio>();
            listOfStudios.Add(studio);

            repositoryMock.Setup(r => r.Entities).Returns(listOfStudios.AsQueryable<Studio>);
            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            service.DeleteStudio(name);

            repositoryMock.Verify(r => r.Delete(studio), Times.Once);
        }

        [TestCase("Studio")]
        public void DeleteStudio_ShouldCallUnitOfWork_WhenStudioIsFound(string name)
        {
            var repositoryMock = new Mock<IRepository<Studio>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var factoryMock = new Mock<IStudioFactory>();
            var studio = new Studio(name, null);
            var listOfStudios = new List<Studio>();
            listOfStudios.Add(studio);
            repositoryMock.Setup(r => r.Entities).Returns(listOfStudios.AsQueryable<Studio>);

            var service = new StudioService(repositoryMock.Object, unitOfWorkMock.Object, factoryMock.Object);
            service.DeleteStudio(name);

            unitOfWorkMock.Verify(u => u.Commit(), Times.Once);
        }
    }
}
