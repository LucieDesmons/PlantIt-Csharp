using BLL.Services;
using DATA.DAL.Context;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace TESTS.IntegrationTests
{
    public class AuthenticationServiceIntegrationTests
    {
        private PlantItContext _dbContext;
        private AuthenticationService _authenticationService;
        private IAuthenticationRepository _authenticationRepository;

        [SetUp]
        public void Setup()
        {
            _dbContext = new PlantItContext();
            _authenticationRepository = new AuthenticationRepository(_dbContext);
            _authenticationService = new AuthenticationService(_authenticationRepository);
        }

        [Test]
        public void GetAuthenticationById_WhenAuthenticationExists_ReturnsAuthenticationDto()
        {
            int idAuthentication = 2;

            var result = _authenticationService.GetAuthenticationById(idAuthentication);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IdAuthentication, Is.EqualTo(idAuthentication));

            Console.WriteLine("Le test GetAuthenticationById_WhenAuthenticationExists_ReturnsAuthenticationDto a réussi !");
            Console.WriteLine("Authentication reçue :");
            Console.WriteLine($"{result.Email} {result.Password}");
        }

        [Test]
        public void UpdateAuthentication_WhenDataIsValid_UpdatesAndReturnsAuthenticationDto()
        {
            int idAuthenticationToUpdate = 4;
            var existingAuthentication = _authenticationService.GetAuthenticationById(idAuthenticationToUpdate);

            var updatedAuthenticationDto = new AuthenticationDto
            {
                IdAuthentication = existingAuthentication.IdAuthentication,
                Email = "updated.email@example.com",
                Password = "updatedpassword"
            };

            var updatedAuthentication = _authenticationService.UpdateAuthentication(updatedAuthenticationDto);

            Assert.That(updatedAuthentication, Is.Not.Null);
            Assert.That(updatedAuthentication.IdAuthentication, Is.EqualTo(updatedAuthenticationDto.IdAuthentication));
            Assert.That(updatedAuthentication.Email, Is.EqualTo(updatedAuthenticationDto.Email));
            Assert.That(BCrypt.Net.BCrypt.Verify(updatedAuthenticationDto.Password, updatedAuthentication.Password), Is.True);

            Console.WriteLine("Le test UpdateAuthentication_WhenDataIsValid_UpdatesAndReturnsAuthenticationDto a réussi !");
            Console.WriteLine("Authentication mise à jour :");
            Console.WriteLine($"{updatedAuthentication.Email} {updatedAuthentication.Password}");
        }

        [Test]
        public void DeleteAuthentication_WhenAuthenticationExists_DeletesAuthentication()
        {
            int idAuthenticationToDelete = 9;

            _authenticationService.DeleteAuthentication(idAuthenticationToDelete);

            // Expecting an exception to be thrown
            var ex = Assert.Throws<Exception>(() => _authenticationService.GetAuthenticationById(idAuthenticationToDelete));

            Assert.That(ex.Message, Is.EqualTo($"Une erreur est survenue lors de la récupération de l'Authentication."));

            Console.WriteLine($"Le test DeleteAuthentication_WhenAuthenticationExists_DeletesAuthentication a réussi !");
            Console.WriteLine($"Authentication avec ID {idAuthenticationToDelete} a été supprimée.");
        }

        [Test]
        public void Authenticate_WithValidEmailAndPassword_AuthenticatesSuccessfully()
        {
            string validEmail = "updated.email@example.com";
            string validPassword = "updatedpassword";

            var authenticatedUser = _authenticationService.Authenticate(validEmail, validPassword);

            Assert.That(authenticatedUser, Is.Not.Null);
            Assert.That(authenticatedUser.Email, Is.EqualTo(validEmail));

            Console.WriteLine($"Le test Authenticate_WithValidEmailAndPassword_AuthenticatesSuccessfully a réussi !");
            Console.WriteLine($"Utilisateur authentifié :");
            Console.WriteLine($"Email: {authenticatedUser.Email}");
        }

        [Test]
        public void Authenticate_WithInvalidEmailAndPassword_ThrowsException()
        {
            string invalidEmail = "invaliduser@example.com";
            string invalidPassword = "wrongpassword";

            Assert.Throws<Exception>(() => _authenticationService.Authenticate(invalidEmail, invalidPassword),
                "Email ou mot de passe incorrect.");

            Console.WriteLine($"Le test Authenticate_WithInvalidEmailAndPassword_ThrowsException a réussi !");
        }

    }
}

