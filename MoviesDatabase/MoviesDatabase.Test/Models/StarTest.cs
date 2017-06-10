using System;
using System.Collections.Generic;
using MoviesDatabase.Models;
using NUnit.Framework;

namespace MoviesDatabase.Test.Models
{
    [TestFixture]
    public class StarTest
    {
        [TestCase("Angelina", "Jolie", 42, "Somewhere")]
        public void Constructor_ShouldSetFirstNamePropertyCorrectly_WhenParameterIsPassed(string firstName, string lastName, int? age, string address)
        {
            var star = new Star(firstName, lastName, age, address);

            Assert.AreEqual(firstName, star.FirstName);
        }

        [TestCase("Angelina", "Jolie", 42, "Somewhere")]
        public void Constructor_ShouldSetLastNamePropertyCorrectly_WhenParameterIsPassed(string firstName, string lastName, int? age, string address)
        {
            var star = new Star(firstName, lastName, age, address);

            Assert.AreEqual(lastName, star.LastName);
        }

        [TestCase("Angelina", "Jolie", 42, "Somewhere")]
        public void Constructor_ShouldSetAgePropertyCorrectly_WhenParameterIsPassed(string firstName, string lastName, int? age, string address)
        {
            var star = new Star(firstName, lastName, age, address);

            Assert.AreEqual(age, star.Age);
        }

        [TestCase("Angelina", "Jolie", 42, "Somewhere")]
        public void Constructor_ShouldSetAddressPropertyCorrectly_WhenParameterIsPassed(string firstName, string lastName, int? age, string address)
        {
            var star = new Star(firstName, lastName, age, address);

            Assert.AreEqual(address, star.Address);
        }

        [TestCase("Angelina", "Jolie", 42, "Somewhere")]
        public void Constructor_ShouldCreateAnInstanceOfStar_WhenParametersAreCorrect(string firstName, string lastName, int? age, string address)
        {
            var star = new Star(firstName, lastName, age, address);

            Assert.IsInstanceOf<Star>(star);
        }

        [TestCase("Angelina", "Jolie", 42, "Somewhere")]
        public void Constructor_ShouldCreateAnInstanceOfHashSet_WhenParametersAreCorrect(string firstName, string lastName, int? age, string address)
        {
            var star = new Star(firstName, lastName, age, address);

            Assert.IsInstanceOf<HashSet<Movie>>(star.Movies);
        }

        [Test]
        public void FirstNameProperty_ShouldWorkCorrectly()
        {
            var star = new Star();
            star.FirstName = "Angelina";

            Assert.AreEqual("Angelina", star.FirstName);
        }

        [Test]
        public void LastNameProperty_ShouldWorkCorrectly()
        {
            var star = new Star();
            star.LastName = "Jolie";

            Assert.AreEqual("Jolie", star.LastName);
        }

        [Test]
        public void AgeProperty_ShouldWorkCorrectly()
        {
            var star = new Star();
            star.Age = 42;

            Assert.AreEqual(42, star.Age);
        }

        [Test]
        public void AddressProperty_ShouldWorkCorrectly()
        {
            var star = new Star();
            star.Address = "Somewhere";

            Assert.AreEqual("Somewhere", star.Address);
        }
    }
}
