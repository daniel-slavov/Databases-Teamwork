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
    public class ProducerServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenRepositoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new ProducerService(
                    null, unitOfWorkMock.Object, producerFactoryMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var producerFactoryMock = new Mock<IProducerFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new ProducerService(
                    producerRepositoryMock.Object, null, producerFactoryMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenFactoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerRepositoryMock = new Mock<IRepository<Producer>>();

            Assert.Throws<ArgumentNullException>(
                () => new ProducerService(
                    producerRepositoryMock.Object, unitOfWorkMock.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenValidParametersPassed()
        {
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();

            Assert.DoesNotThrow(
                () => new ProducerService(
                    producerRepositoryMock.Object, unitOfWorkMock.Object, producerFactoryMock.Object));
        }

        [Test]
        public void AddProducers_ShouldCallRepositoryAddMethod_WhenValidParametersPassed()
        {
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();
            var producerService = new ProducerService(
                producerRepositoryMock.Object, unitOfWorkMock.Object, producerFactoryMock.Object);
            var producers = new List<Producer>()
            {
                new Producer("James Cameron"),
                new Producer("Steven Spielberg")
            };

            producerService.AddProducers(producers);

            producerRepositoryMock.Verify(r => r.Add(It.IsAny<Producer>()), Times.Exactly(producers.Count));
        }

        [Test]
        public void AddProducers_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();
            var producerService = new ProducerService(
                producerRepositoryMock.Object, unitOfWorkMock.Object, producerFactoryMock.Object);

            var producers = new List<Producer>()
            {
                new Producer("James Cameron"),
                new Producer("Steven Spielberg")
            };

            producerService.AddProducers(producers);

            unitOfWorkMock.Verify(n => n.Commit(), Times.Once);
        }

        [Test]
        public void CreateProducer_ShouldCallFactoryCreateProducerMethod_WhenValidParametersPassed()
        {
            var name = "Steven Spielberg";
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();
            var producerService = new ProducerService(
                producerRepositoryMock.Object, unitOfWorkMock.Object, producerFactoryMock.Object);

            producerService.CreateProducer(name);

            producerFactoryMock.Verify(f => f.CreateProducer(name), Times.Once);
        }

        [Test]
        public void CreateProducer_ShouldCallRepositoryAddMethod_WhenValidParametersPassed()
        {
            var name = "Steven Spielberg";
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();
            var producerService = new ProducerService(
                producerRepositoryMock.Object, unitOfWorkMock.Object, producerFactoryMock.Object);

            producerService.CreateProducer(name);

            producerRepositoryMock.Verify(r => r.Add(It.IsAny<Producer>()), Times.Once);
        }

        [Test]
        public void CreateProducer_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var name = "Steven Spielberg";
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();
            var producerService = new ProducerService(
                producerRepositoryMock.Object, unitOfWorkMock.Object, producerFactoryMock.Object);

            producerService.CreateProducer(name);

            unitOfWorkMock.Verify(u => u.Commit(), Times.Once);
        }

        [Test]
        public void CreateProducer_ShouldReturnCorrectProducer_WhenValidParametersPassed()
        {
            var name = "Steven Spielberg";
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();
            var producer = new Producer(name);
            producerFactoryMock.Setup(f => f.CreateProducer(name)).Returns(producer);
            var producerService = new ProducerService(
                producerRepositoryMock.Object, unitOfWorkMock.Object, producerFactoryMock.Object);

            var returnedProducer = producerService.CreateProducer(name);

            Assert.AreSame(producer, returnedProducer);
        }

        [Test]
        public void GetProducerBy_ShouldCallRepository_WhenValidParametersPassed()
        {
            var name = "Steven Spielberg";
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();
            var producerService = new ProducerService(
                producerRepositoryMock.Object, unitOfWorkMock.Object, producerFactoryMock.Object);

            producerService.GetProducerBy(name);

            producerRepositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [Test]
        public void GetProducerBy_ShouldReturnCorrectProducer_WhenValidParametersPassed()
        {
            var name = "Steven Spielberg";
            var producerRepositoryMock = new Mock<IRepository<Producer>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var producerFactoryMock = new Mock<IProducerFactory>();
            var producer = new Producer(name);
            var list = new List<Producer>() { producer };
            var queryableProducers = list.AsQueryable();

            producerRepositoryMock.Setup(r => r.Entities).Returns(queryableProducers);
            var producerService = new ProducerService(
                producerRepositoryMock.Object, unitOfWorkMock.Object, producerFactoryMock.Object);

            var returnedProducer = producerService.GetProducerBy(name);

            Assert.AreSame(producer, returnedProducer);
        }

    }
}
