using System;
using MoviesDatabase.Models;
using NUnit.Framework;

namespace MoviesDatabase.Test.Models
{
    [TestFixture]
    public class BookTest
    {
        [TestCase("Book", "Me", 1987)]
        public void Constructor_ShouldSetTitlePropertyCorrectly_WhenParameterIsPassed(string title, string author, int? year)
        {
            var book = new Book(title, author, year);

            Assert.AreEqual(title, book.Title);
        }

        [TestCase("Book", "Me", 1987)]
        public void Constructor_ShouldSetAuthorPropertyCorrectly_WhenParameterIsPassed(string title, string author, int? year)
        {
            var book = new Book(title, author, year);

            Assert.AreEqual(author, book.Author);
        }

        [TestCase("Book", "Me", 1987)]
        public void Constructor_ShouldSetYearPropertyCorrectly_WhenParameterIsPassed(string title, string author, int? year)
        {
            var book = new Book(title, author, year);

            Assert.AreEqual(year, book.Year);
        }

        [TestCase("Book", "Me", 1987)]
        public void Constructor_ShouldCreateAnInstanceOfStudio_WhenParametersAreCorrect(string title, string author, int? year)
        {
            var book = new Book(title, author, year);

            Assert.IsInstanceOf<Book>(book);
        }

        [Test]
        public void TitleProperty_ShouldWorkCorrectly()
        {
            var book = new Book();
            book.Title = "Book";

            Assert.AreEqual("Book", book.Title);
        }

        [Test]
        public void AuthorProperty_ShouldWorkCorrectly()
        {
            var book = new Book();
            book.Author = "Me";

            Assert.AreEqual("Me", book.Author);
        }

        [Test]
        public void YearProperty_ShouldWorkCorrectly()
        {
            var book = new Book();
            book.Year = 1958;

            Assert.AreEqual(1958, book.Year);
        }
    }
}
