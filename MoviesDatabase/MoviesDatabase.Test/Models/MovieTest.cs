using System;
using System.Collections.Generic;
using MoviesDatabase.Models;
using NUnit.Framework;

namespace MoviesDatabase.Test.Models
{
    [TestFixture]
    public class MovieTest
    {
        [Test]
        public void Constructor_ShouldSetTitlePropertyCorrectly_WhenParameterIsPassed()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.AreEqual(title, movie.Title);
        }

        [Test]
        public void Constructor_ShouldSetYearPropertyCorrectly_WhenParameterIsPassed()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.AreEqual(year, movie.Year);
        }

        [Test]
        public void Constructor_ShouldSetDescriptionPropertyCorrectly_WhenParameterIsPassed()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.AreEqual(description, movie.Description);
        }

        [Test]
        public void Constructor_ShouldSetLengthPropertyCorrectly_WhenParameterIsPassed()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.AreEqual(length, movie.Length);
        }

        [Test]
        public void Constructor_ShouldSetProducerPropertyCorrectly_WhenParameterIsPassed()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.AreSame(producer, movie.Producer);
        }

        [Test]
        public void Constructor_ShouldSetStudioPropertyCorrectly_WhenParameterIsPassed()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.AreSame(studio, movie.Studio);
        }

        [Test]
        public void Constructor_ShouldSetBookPropertyCorrectly_WhenParameterIsPassed()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.AreSame(book, movie.Book);
        }

        [Test]
        public void Constructor_ShouldSetGenresPropertyCorrectly_WhenParameterIsPassed()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.AreSame(genres, movie.Genres);
        }

        [Test]
        public void Constructor_ShouldSetStarsPropertyCorrectly_WhenParameterIsPassed()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.AreSame(stars, movie.Stars);
        }

        [Test]
        public void Constructor_ShouldCreateAnInstanceOfMovie_WhenParametersAreCorrect()
        {
            string title = "Avatar";
            int year = 2010;
            string description = "desc";
            int length = 150;
            Producer producer = new Producer();
            Studio studio = new Studio();
            Book book = new Book();
            ICollection<Genre> genres = new HashSet<Genre>();
            ICollection<Star> stars = new HashSet<Star>();
            var movie = new Movie(title, year, description, length, producer, studio, book, genres, stars);

            Assert.IsInstanceOf<Movie>(movie);
        }

        [Test]
        public void TitleProperty_ShouldWorkCorrectly()
        {
            var movie = new Movie();
            movie.Title = "Avatar";

            Assert.AreEqual("Avatar", movie.Title);
        }

        [Test]
        public void YearProperty_ShouldWorkCorrectly()
        {
            var movie = new Movie();
            movie.Year = 2010;

            Assert.AreEqual(2010, movie.Year);
        }

        [Test]
        public void DescriptionProperty_ShouldWorkCorrectly()
        {
            var movie = new Movie();
            movie.Description = "desc";

            Assert.AreEqual("desc", movie.Description);
        }

        [Test]
        public void LengthProperty_ShouldWorkCorrectly()
        {
            var movie = new Movie();
            movie.Length = 150;

            Assert.AreEqual(150, movie.Length);
        }

        [Test]
        public void ProducerProperty_ShouldWorkCorrectly()
        {
            var movie = new Movie();
            var producer = new Producer();
            movie.Producer = producer;

            Assert.AreSame(producer, movie.Producer);
        }

        [Test]
        public void StudioProperty_ShouldWorkCorrectly()
        {
            var movie = new Movie();
            var studio = new Studio();
            movie.Studio = studio;

            Assert.AreSame(studio, movie.Studio);
        }

        [Test]
        public void BookProperty_ShouldWorkCorrectly()
        {
            var movie = new Movie();
            var book = new Book();
            movie.Book = book;

            Assert.AreSame(book, movie.Book);
        }

        [Test]
        public void GenresProperty_ShouldWorkCorrectly()
        {
            var movie = new Movie();
            var genres = new HashSet<Genre>();
            movie.Genres = genres;

            Assert.AreSame(genres, movie.Genres);
        }

        [Test]
        public void StarsProperty_ShouldWorkCorrectly()
        {
            var movie = new Movie();
            var stars = new HashSet<Star>();
            movie.Stars = stars;

            Assert.AreSame(stars, movie.Stars);
        }
    }
}
