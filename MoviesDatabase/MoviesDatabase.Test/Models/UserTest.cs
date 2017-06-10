using System;
using MoviesDatabase.Models;
using NUnit.Framework;

namespace MoviesDatabase.Test.Models
{
    [TestFixture]
    public class UserTest
    {
        [TestCase("username", "123456")]
        public void Constructor_ShouldSetUsernamePropertyCorrectly_WhenParameterIsPassed(string username, string password)
        {
            var user = new User(username, password);

            Assert.AreEqual(username, user.Username);
        }

        [TestCase("username", "123456")]
        public void Constructor_ShouldSetPassHashPropertyCorrectly_WhenParameterIsPassed(string username, string password)
        {
            var user = new User(username, password);

            Assert.AreEqual(password, user.PassHash);
        }

        [TestCase("username", "123456")]
        public void Constructor_ShouldCreateAnInstanceOfStudio_WhenParametersAreCorrect(string username, string password)
        {
            var user = new User(username, password);

            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void UserNameProperty_ShouldWorkCorrectly()
        {
            var user = new User();
            user.Username = "username";

            Assert.AreEqual("username", user.Username);
        }

        [Test]
        public void PassHashProperty_ShouldWorkCorrectly()
        {
            var user = new User();
            user.PassHash = "123456";

            Assert.AreEqual("123456", user.PassHash);
        }
    }
}
