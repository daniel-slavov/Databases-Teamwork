using Moq;
using MoviesDatabase.Data;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Test.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUserRepositoryIsNull()
        {
            Repository<User> userRepository = null;

            Assert.Throws<ArgumentNullException>(() => new UserService(userRepository));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenUserRepositoryIsNotNull()
        {
            var userRepositoryMock = new Mock<IRepository<User>>();

            Assert.DoesNotThrow(() => new UserService(userRepositoryMock.Object));
        }

        [Test]
        public void GetUser_ShouldCallRepository_WhenPassedValidParameters()
        {
            var username = "test";
            var password = "1234";
            var userRepositoryMock = new Mock<IRepository<User>>();
            var userService = new UserService(userRepositoryMock.Object);

            userService.GetUser(username, password);

            userRepositoryMock.Verify(u => u.Entities, Times.Once);
        }

        [Test]
        public void GetUser_ShouldReturnCorrectUser_WhenPassedValidParameters()
        {
            var username = "test";
            var password = "1234";
            var userRepositoryMock = new Mock<IRepository<User>>();
            var expectedUser = new User(username, password);
            var users = new List<User> { expectedUser };
            var queryableUsers = users.AsQueryable();
            userRepositoryMock.Setup(u => u.Entities).Returns(queryableUsers);
            var userService = new UserService(userRepositoryMock.Object);

            var returnedUser = userService.GetUser(username, password);

            Assert.AreSame(expectedUser, returnedUser);
        }
    }
}
