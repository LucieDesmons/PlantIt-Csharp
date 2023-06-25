using BLL.Services;
using DATA.DAL.Repositories;
using Moq;

namespace TESTS.UnitTests
{
    public class AuthenticationServiceUnitTests
    {
        private AuthenticationService _authenticationService;
        private Mock<IAuthentificationRepository> _authenticationRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _authenticationRepositoryMock = new Mock<IAuthentificationRepository>();
            _authenticationService = new AuthenticationService(_authenticationRepositoryMock.Object);
        }

        [Test]
        public void GetAuthentificationById_WhenAuthentificationExists_ReturnsAuthentificationDto()
        {
            // Arrange
            int idAuthentification = 1;
            var authentification = new DATA.DAL.Entities.Authentification
            {
                IdAuthentification = idAuthentification,
                Email = "desmons.lucie@gmail.com",
                Password = "lucie"
            };
            _authenticationRepositoryMock.Setup(repo => repo.GetAuthentificationById(idAuthentification)).Returns(authentification);

            // Act
            var result = _authenticationService.GetAuthentificationById(idAuthentification);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(authentification.Email, result.Email);

            Console.WriteLine("Le test GetAuthentificationById_WhenAuthentificationExists_ReturnsAuthentificationDto a réussi !");
            Console.WriteLine("Authentification attendue :");
            Console.WriteLine($"{authentification.Email} {authentification.Password}");
            Console.WriteLine("Authentification reçue :");
            Console.WriteLine($"{result.Email} {result.Password}");
        }
    }
}

