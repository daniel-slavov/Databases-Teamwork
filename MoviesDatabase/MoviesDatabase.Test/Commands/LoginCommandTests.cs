using Moq;
using MoviesDatabase.CLI.Commands;
using MoviesDatabase.Models;
using MoviesDatabase.Services.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Test.Commands
{
    [TestFixture]
    class LoginCommandTests
    {
        private Mock<IUserService> userServiceMock;

        [SetUp]
        public void ServicesSetup()
        {
            userServiceMock = new Mock<IUserService>();
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenAllServicesAreProvided()
        {
            Assert.DoesNotThrow(() => new LoginCommand(userServiceMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUserServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new LoginCommand(null));
        }

        [Test]
        public void Execute_ShouldCallAppropriateMethodAndReturnSuccessMessage()
        {
            var loginCommand = new LoginCommand(userServiceMock.Object);
            userServiceMock.Setup(x => x.GetUser("", "")).Returns(new User());
            var expectedValue = "Login successful.";

            var returnValue = loginCommand.Execute(new List<string>() { "", "" });

            userServiceMock.Verify(x => x.GetUser("", ""));
            StringAssert.AreEqualIgnoringCase(expectedValue, returnValue);
        }

        [Test]
        public void Execute_ShouldThrowNullRefferenceException_WhenUserIsNotFound()
        {
            var loginCommand = new LoginCommand(userServiceMock.Object);
            userServiceMock.Setup(x => x.GetUser("", "")).Returns((User)null);

            Assert.Throws<NullReferenceException>(() => loginCommand.Execute(new List<string>() { "", "" }));
        }

        [Test]
        public void Execute_ShouldThrowArgumentException_WhenCalledWithLessThanTwoParameters()
        {
            var loginCommand = new LoginCommand(userServiceMock.Object);

            Assert.Throws<ArgumentException>(() => loginCommand.Execute(new List<string>() { "" }), "Missing username and/or password.");
        }

        [Test]
        public void Execute_ShouldThrowArgumentException_WhenCalledWithNullParameter()
        {
            var loginCommand = new LoginCommand(userServiceMock.Object);

            Assert.Throws<ArgumentException>(() => loginCommand.Execute(null), "Missing username and/or password.");
        }
    }
}
