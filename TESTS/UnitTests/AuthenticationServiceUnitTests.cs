using BLL.Services;
using DATA.DAL.Repositories;
using Moq;

namespace TESTS.UnitTests
{
    public class AuthenticationServiceUnitTests
    {
        private AuthenticationService _authenticationService;
        private Mock<IAuthenticationRepository> _authenticationRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _authenticationRepositoryMock = new Mock<IAuthenticationRepository>();
            _authenticationService = new AuthenticationService(_authenticationRepositoryMock.Object);
        }

        [Test]
        public void GetAuthenticationById_WhenAuthenticationExists_ReturnsAuthenticationDto()
        {
            // Arrange
            int idAuthentication = 1;
            var Authentication = new DATA.DAL.Entities.Authentication
            {
                IdAuthentication = idAuthentication,
                Email = "desmons.lucie@gmail.com",
                Password = "lucie"
            };
            _authenticationRepositoryMock.Setup(repo => repo.GetAuthenticationById(idAuthentication)).Returns(Authentication);

            // Act
            var result = _authenticationService.GetAuthenticationById(idAuthentication);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Authentication.Email, result.Email);

            Console.WriteLine("Le test GetAuthenticationById_WhenAuthenticationExists_ReturnsAuthenticationDto a réussi !");
            Console.WriteLine("Authentication attendue :");
            Console.WriteLine($"{Authentication.Email} {Authentication.Password}");
            Console.WriteLine("Authentication reçue :");
            Console.WriteLine($"{result.Email} {result.Password}");
        }
    }
}

