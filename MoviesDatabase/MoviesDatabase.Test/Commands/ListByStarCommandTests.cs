using Moq;
using MoviesDatabase.CLI.Commands;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Models;
using MoviesDatabase.Services.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MoviesDatabase.Test.Commands
{
    [TestFixture]
    public class ListByStarCommandTests
    {
        private Mock<IMovieService> movieServiceMock;
        private Mock<ITableCreator> tableCreatorMock;

        [SetUp]
        public void ServicesSetup()
        {
            movieServiceMock = new Mock<IMovieService>();
            tableCreatorMock = new Mock<ITableCreator>();
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenAllServicesAreProvided()
        {
            Assert.DoesNotThrow(() => new ListByStarCommand(movieServiceMock.Object, tableCreatorMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenMovieServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ListByStarCommand(null, tableCreatorMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenTableCreatorIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ListByStarCommand(movieServiceMock.Object, null));
        }

        [Test]
        public void Execute_ShouldReturnCorrectString()
        {
            var listByStarCommand = new ListByStarCommand(movieServiceMock.Object, tableCreatorMock.Object);
            var expectedResult = "test string";
            movieServiceMock.Setup(x => x.GetMoviesByStar("")).Returns(new List<Movie>());
            movieServiceMock.Setup(x => x.ConvertForPrint(new List<Movie>())).Returns(new List<MovieForPrint>());
            tableCreatorMock.Setup(x => x.CreateTable<MovieForPrint>(new List<MovieForPrint>())).Returns(expectedResult);

            var actualResult = listByStarCommand.Execute(new List<string>());

            StringAssert.AreEqualIgnoringCase(expectedResult, actualResult);
        }

        [Test]
        public void Execute_ShouldThrowNullReferenceException_WhenNoMoviesAreReturnedFromDatabase()
        {
            var listByStarCommand = new ListByStarCommand(movieServiceMock.Object, tableCreatorMock.Object);
            movieServiceMock.Setup(x => x.GetMoviesByStar("")).Returns((IEnumerable<Movie>)null);

            Assert.Throws<NullReferenceException>(() => listByStarCommand.Execute(new List<string>() { "" }));
        }
    }
}
