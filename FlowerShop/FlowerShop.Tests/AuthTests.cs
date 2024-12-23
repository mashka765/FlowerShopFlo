using Moq;
using System;
using Xunit;
using FlowerShop;



namespace FlowerShop.Tests
{
    internal class AuthTests
    {
        private readonly Mock<AuthService> _authServiceMock;

        public AuthTests()
        {
            _authServiceMock = new Mock<AuthService>("FakeConnectionString");
        }

        [Fact]
        public void Authenticate_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string login = "validUser";
            string password = "validPassword";

            _authServiceMock
                .Setup(service => service.Authenticate(login, password))
                .Returns(true);

            var authService = _authServiceMock.Object;

            // Act
            bool result = authService.Authenticate(login, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Authenticate_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            string login = "invalidUser";
            string password = "invalidPassword";

            _authServiceMock
                .Setup(service => service.Authenticate(login, password))
                .Returns(false);

            var authService = _authServiceMock.Object;

            // Act
            bool result = authService.Authenticate(login, password);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Authenticate_EmptyLogin_ThrowsArgumentException()
        {
            // Arrange
            string login = "";
            string password = "password";

            _authServiceMock
                .Setup(service => service.Authenticate(login, password))
                .Throws(new ArgumentException("Login and password cannot be empty."));

            var authService = _authServiceMock.Object;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => authService.Authenticate(login, password));
        }

        [Fact]
        public void Authenticate_EmptyPassword_ThrowsArgumentException()
        {
            // Arrange
            string login = "user";
            string password = "";

            _authServiceMock
                .Setup(service => service.Authenticate(login, password))
                .Throws(new ArgumentException("Login and password cannot be empty."));

            var authService = _authServiceMock.Object;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => authService.Authenticate(login, password));
        }

        [Fact]
        public void Authenticate_SqlConnectionError_ThrowsException()
        {
            // Arrange
            string login = "user";
            string password = "password";

            _authServiceMock
                .Setup(service => service.Authenticate(login, password))
                .Throws(new Exception("Database connection error."));

            var authService = _authServiceMock.Object;

            // Act & Assert
            Assert.Throws<Exception>(() => authService.Authenticate(login, password));
        }
    }
}


