using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using MoviesDatabase.Models;

namespace MoviesDatabase.Test.Models
{
    [TestFixture]
    public class StudioTest
    {
        [TestCase("Studio", "Address")]
        public void Constructor_ShouldSetNamePropertyCorrectly_WhenParameterIsPassed(string name, string address)
        {
            var studio = new Studio(name, address);

            Assert.AreEqual(name, studio.Name);
        }

        [TestCase("Studio", "Address")]
        public void Constructor_ShouldSetAddressPropertyCorrectly_WhenParameterIsPassed(string name, string address)
        {
            var studio = new Studio(name, address);

            Assert.AreEqual(address, studio.Address);
        }

        [TestCase("Studio", "Address")]
        public void Constructor_ShouldCreateAnInstanceOfStudio_WhenParametersAreCorrect(string name, string address)
        {
            var studio = new Studio(name, address);

            Assert.IsInstanceOf<Studio>(studio);
        }

        [Test]
        public void NameProperty_ShouldWorkCorrectly()
        {
            var studio = new Studio();
            studio.Name = "Studio";

            Assert.AreEqual("Studio", studio.Name);
        }

        [Test]
        public void AddressProperty_ShouldWorkCorrectly()
        {
            var studio = new Studio();
            studio.Address = "Address";

            Assert.AreEqual("Address", studio.Address);
        }
    }
}
