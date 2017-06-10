using System;
using System.Collections.Generic;
using MoviesDatabase.Models;
using NUnit.Framework;

namespace MoviesDatabase.Test.Models
{
    [TestFixture]
    public class GenreTest
    {
        [TestCase("Action")]
        public void Constructor_ShouldSetFirstNamePropertyCorrectly_WhenParameterIsPassed(string name)
        {
            var genre = new Genre(name);

            Assert.AreEqual(name, genre.Name);
        }

        [TestCase("Action")]
        public void Constructor_ShouldCreateAnInstanceOfStudio_WhenParametersAreCorrect(string name)
        {
            var genre = new Genre(name);

            Assert.IsInstanceOf<Genre>(genre);
        }

        [TestCase("Action")]
        public void Constructor_ShouldCreateAnInstanceOfHashSet_WhenParametersAreCorrect(string name)
        {
            var genre = new Genre(name);

            Assert.IsInstanceOf<HashSet<Movie>>(genre.Movies);
        }

        [Test]
        public void NameProperty_ShouldWorkCorrectly()
        {
            var genre = new Genre();
            genre.Name = "Action";

            Assert.AreEqual("Action", genre.Name);
        }
    }
}
