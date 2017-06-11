using Moq;
using MoviesDatabase.CLI.Commands;
using MoviesDatabase.Models;
using MoviesDatabase.Services.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MoviesDatabase.Test.Commands
{
    [TestFixture]
    public class UpdateCommandTests
    {
        private Mock<IBookService> bookServiceMock;
        private Mock<IStarService> starServiceMock;
        private Mock<IStudioService> studioServiceMock;

        [SetUp]
        public void ServicesSetup()
        {
            bookServiceMock = new Mock<IBookService>();
            starServiceMock = new Mock<IStarService>();
            studioServiceMock = new Mock<IStudioService>();
        }
        
        [Test]
        public void Constructor_ShouldNotThrow_WhenAllServicesAreProvided()
        {
            Assert.DoesNotThrow(() => new UpdateCommand(bookServiceMock.Object, starServiceMock.Object, studioServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenBookServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UpdateCommand(null, starServiceMock.Object, studioServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenStarServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UpdateCommand(bookServiceMock.Object, null, studioServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenStudioServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UpdateCommand(bookServiceMock.Object, starServiceMock.Object, null));
        }

        [Test]
        public void Execute_ShouldCallTheAppropriateMethod_WhenUpdatingABook()
        {
            var updateCommand = new UpdateCommand(bookServiceMock.Object, starServiceMock.Object, studioServiceMock.Object);
            var bookModel = new Book();
            bookServiceMock.Setup(x => x.GetBookByTitle("")).Returns(bookModel);
            var model = "Book";

            var returnValue = updateCommand.Execute(new List<string>() { model, "" });

            bookServiceMock.Verify(x => x.UpdateBook(bookModel));
        }

        [Test]
        public void Execute_ShouldCallTheAppropriateMethod_WhenUpdatingAStar()
        {
            var updateCommand = new UpdateCommand(bookServiceMock.Object, starServiceMock.Object, studioServiceMock.Object);
            var starModel = new Star();
            starServiceMock.Setup(x => x.GetStarByName("Pesho", "Peshov")).Returns(starModel);
            var model = "Star";

            updateCommand.Execute(new List<string>() { model, "Pesho_Peshov" });

            starServiceMock.Verify(x => x.UpdateStar(starModel));
        }

        [Test]
        public void Execute_ShouldCallTheAppropriateMethod_WhenUpdatingAStudio()
        {
            var updateCommand = new UpdateCommand(bookServiceMock.Object, starServiceMock.Object, studioServiceMock.Object);
            var studioModel = new Studio();
            studioServiceMock.Setup(x => x.GetStudioByName("")).Returns(studioModel);
            var model = "Studio";

            updateCommand.Execute(new List<string>() { model, "" });

            studioServiceMock.Verify(x => x.UpdateStudio(studioModel));
        }

        [TestCase("Genre")]
        [TestCase("Producer")]
        public void Execute_ShouldThrowArgumentException_WhenModelIsNotSupported(string model)
        {
            var updateCommand = new UpdateCommand(bookServiceMock.Object, starServiceMock.Object, studioServiceMock.Object);

            Assert.Throws<ArgumentException>(() => updateCommand.Execute(new List<string>() { model, "" }), " was updated successfully.");
        }
    }
}
