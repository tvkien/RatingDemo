using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RatingDemo.BackendApi.Businesses;
using RatingDemo.BackendApi.Controllers;
using RatingDemo.BackendApi.Models;
using System;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi.Tests
{
    [TestFixture]
    public class UsersControllerTest
    {
        private Mock<IUsersService> usersService;
        private UsersController usersController;

        [SetUp]
        public void Setup()
        {
            usersService = new Mock<IUsersService>();
            usersController = new UsersController(usersService.Object);
        }

        [Test]
        public async Task ShouldReturnTheValidJWTToken()
        {
            //Arrange
            const string tokens = "abc.123456789.xyz";
            usersService.Setup(x => x.AuthenticateAsync(It.IsAny<LoginRequest>())).Returns(Task.FromResult(tokens));

            //Action
            var response = await usersController.AuthenticateAsync(It.IsAny<LoginRequest>()) as OkObjectResult;
            var result = response.Value as string;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, tokens);
        }

        [Test]
        public async Task ShouldReturnThePasscodeIncorrect()
        {
            //Arrange
            const string message = "Passcode is incorrect.";
            usersService.Setup(x => x.AuthenticateAsync(It.IsAny<LoginRequest>())).Returns(Task.FromResult(string.Empty));

            //Action
            var response = await usersController.AuthenticateAsync(It.IsAny<LoginRequest>()) as BadRequestObjectResult;
            var result = response.Value as string;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, message);
        }

        [Test]
        public void ShouldThrowExceptionWhenServiceError()
        {
            //Arrange
            usersService.Setup(x => x.AuthenticateAsync(It.IsAny<LoginRequest>())).Throws<Exception>();

            //Action
            Assert.ThrowsAsync<Exception>(
                () => usersController.AuthenticateAsync(It.IsAny<LoginRequest>()));
        }
    }
}