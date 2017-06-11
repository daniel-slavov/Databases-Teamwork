using Moq;
using MoviesDatabase.CLI.Commands;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Test.Commands
{
    [TestFixture]
    public class AddCommandTests
    {
        private Mock<IMovieService> movieServiceMock;
        private Mock<IReader> readerMock;
        private Mock<IWriter> writerMock;

        [SetUp]
        public void ServicesSetup()
        {
            movieServiceMock = new Mock<IMovieService>();
            readerMock = new Mock<IReader>();
            writerMock = new Mock<IWriter>();
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenAllServicesAreProvided()
        {
            Assert.DoesNotThrow(() => new AddCommand(movieServiceMock.Object, readerMock.Object, writerMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenMovieServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddCommand(null, readerMock.Object, writerMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenReaderIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddCommand(movieServiceMock.Object, null, writerMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenWriterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddCommand(movieServiceMock.Object, readerMock.Object, null));
        }

        [Test]
        public void Execute_ShouldReturnSuccessMessage_WhenAllDataIsRead()
        {
            var addCommand = new AddCommand(movieServiceMock.Object, readerMock.Object, writerMock.Object);
            readerMock.Setup(x => x.ReadLine()).Returns("10");
            var expectedValue = "Movie was added successfully.";

            var returnValue = addCommand.Execute(new List<string>());

            StringAssert.AreEqualIgnoringCase(expectedValue, returnValue);
        }
    }
}
