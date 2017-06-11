using Moq;
using MoviesDatabase.Services.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.CLI.Commands;

namespace MoviesDatabase.Test.Commands
{
    [TestFixture]
    public class DeleteCommandTests
    {
        private Mock<IBookService> bookServiceMock;
        private Mock<IMovieService> movieServiceMock;
        private Mock<IStarService> starServiceMock;
        private Mock<IStudioService> studioServiceMock;

        [SetUp]
        public void ServicesSetup()
        {
           bookServiceMock = new Mock<IBookService>();
           movieServiceMock = new Mock<IMovieService>();
           starServiceMock = new Mock<IStarService>();
           studioServiceMock = new Mock<IStudioService>();
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenAllServicesAreProvided()
        {
            Assert.DoesNotThrow(() => new DeleteCommand(bookServiceMock.Object, movieServiceMock.Object, starServiceMock.Object, studioServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenBookServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteCommand(null, movieServiceMock.Object, starServiceMock.Object, studioServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenMovieServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteCommand(bookServiceMock.Object, null, starServiceMock.Object, studioServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenStarServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteCommand(bookServiceMock.Object, movieServiceMock.Object, null, studioServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenStudioServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteCommand(bookServiceMock.Object, movieServiceMock.Object, starServiceMock.Object, null));
        }

        [Test]
        public void Execute_ShouldCallAppropriateMethod_WhenDeletingABook()
        {
            var deleteCommand = new DeleteCommand(bookServiceMock.Object, movieServiceMock.Object, starServiceMock.Object, studioServiceMock.Object);
            var model = "Book";
            var name = "Some_book";

            var returnValue = deleteCommand.Execute(new List<string>() { model , name });

            bookServiceMock.Verify(x => x.DeleteBook(name.Replace('_', ' ')));
            StringAssert.AreEqualIgnoringCase($"{model} {name.Replace('_', ' ')} was deleted successfully.", returnValue);
        }

        [Test]
        public void Execute_ShouldCallAppropriateMethod_WhenDeletingAMovie()
        {
            var deleteCommand = new DeleteCommand(bookServiceMock.Object, movieServiceMock.Object, starServiceMock.Object, studioServiceMock.Object);
            var model = "Movie";
            var name = "Test_Movie";

            var returnValue = deleteCommand.Execute(new List<string>() { model, name });

            movieServiceMock.Verify(x => x.DeleteMovie(name.Replace('_', ' ')));
            StringAssert.AreEqualIgnoringCase($"{model} {name.Replace('_', ' ')} was deleted successfully.", returnValue);
        }

        [Test]
        public void Execute_ShouldCallAppropriateMethod_WhenDeletingAStar()
        {
            var deleteCommand = new DeleteCommand(bookServiceMock.Object, movieServiceMock.Object, starServiceMock.Object, studioServiceMock.Object);
            var model = "Star";
            var firstName = "Pesho";
            var lastName = "Peshov";

            var returnValue = deleteCommand.Execute(new List<string>() { model, $"{firstName}_{lastName}" });

            starServiceMock.Verify(x => x.DeleteStar(firstName, lastName));
            StringAssert.AreEqualIgnoringCase($"{model} {firstName} {lastName} was deleted successfully.", returnValue);
        }

        [Test]
        public void Execute_ShouldCallAppropriateMethod_WhenDeletingAStudio()
        {
            var deleteCommand = new DeleteCommand(bookServiceMock.Object, movieServiceMock.Object, starServiceMock.Object, studioServiceMock.Object);
            var model = "Studio";
            var name = "Test_Studio";

            var returnValue = deleteCommand.Execute(new List<string>() { model, name });

            studioServiceMock.Verify(x => x.DeleteStudio(name.Replace('_', ' ')));
            StringAssert.AreEqualIgnoringCase($"{model} {name.Replace('_', ' ')} was deleted successfully.", returnValue);
        }

        [TestCase("Genre")]
        [TestCase("Producer")]
        public void Execute_ShouldThrowArgumentException_WhenInvalidTypeIspassedForDeletion(string model)
        {
            var deleteCommand = new DeleteCommand(bookServiceMock.Object, movieServiceMock.Object, starServiceMock.Object, studioServiceMock.Object);
            var name = "test";

            Assert.Throws<ArgumentException>(() => deleteCommand.Execute(new List<string>() { model, name }), $"{model}s cannot be deleted.");
        }
    }
}
