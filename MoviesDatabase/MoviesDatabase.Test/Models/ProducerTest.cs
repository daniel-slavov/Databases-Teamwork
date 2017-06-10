using System;
using System.Text;
using System.Collections.Generic;
using MoviesDatabase.Models;
using NUnit.Framework;

namespace MoviesDatabase.Test.Models
{
    [TestFixture]
    public class ProducerTest
    {
        [TestCase("John")]
        public void Constructor_ShouldSetNamePropertyCorrectly_WhenParameterIsPassed(string name)
        {
            var producer = new Producer(name);

            Assert.AreEqual(name, producer.Name);
        }

        [TestCase("John")]
        public void Constructor_ShouldCreateAnInstanceOfStudio_WhenParametersAreCorrect(string name)
        {
            var producer = new Producer(name);

            Assert.IsInstanceOf<Producer>(producer);
        }

        [Test]
        public void NameProperty_ShouldWorkCorrectly()
        {
            var producer = new Producer();
            producer.Name = "John";

            Assert.AreEqual("John", producer.Name);
        }  
    }
}
