using BLL.Services;
using DATA.DAL.DbContextt;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace TESTS.IntegrationTests
{
    public class AuthenticationServiceIntegrationTests
    {
        private PlantItContext _dbContext;
        private AuthenticationService _authenticationService;
        private IAuthentificationRepository _authenticationRepository;

        [SetUp]
        public void Setup()
        {
            _dbContext = new PlantItContext();
            _authenticationRepository = new AuthentificationRepository(_dbContext);
            _authenticationService = new AuthenticationService(_authenticationRepository);
        }

        [Test]
        public void GetAuthentificationById_WhenAuthentificationExists_ReturnsAuthentificationDto()
        {
            int idAuthentification = 2;

            var result = _authenticationService.GetAuthentificationById(idAuthentification);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IdAuthentification, Is.EqualTo(idAuthentification));

            Console.WriteLine("Le test GetAuthentificationById_WhenAuthentificationExists_ReturnsAuthentificationDto a réussi !");
            Console.WriteLine("Authentification reçue :");
            Console.WriteLine($"{result.Email} {result.Password}");
        }

        [Test]
        public void UpdateAuthentification_WhenDataIsValid_UpdatesAndReturnsAuthentificationDto()
        {
            int idAuthentificationToUpdate = 4;
            var existingAuthentification = _authenticationService.GetAuthentificationById(idAuthentificationToUpdate);

            var updatedAuthentificationDto = new AuthentificationDto
            {
                IdAuthentification = existingAuthentification.IdAuthentification,
                Email = "updated.email@example.com",
                Password = "updatedpassword"
            };

            var updatedAuthentification = _authenticationService.UpdateAuthentification(updatedAuthentificationDto);

            Assert.That(updatedAuthentification, Is.Not.Null);
            Assert.That(updatedAuthentification.IdAuthentification, Is.EqualTo(updatedAuthentificationDto.IdAuthentification));
            Assert.That(updatedAuthentification.Email, Is.EqualTo(updatedAuthentificationDto.Email));
            Assert.That(BCrypt.Net.BCrypt.Verify(updatedAuthentificationDto.Password, updatedAuthentification.Password), Is.True);

            Console.WriteLine("Le test UpdateAuthentification_WhenDataIsValid_UpdatesAndReturnsAuthentificationDto a réussi !");
            Console.WriteLine("Authentification mise à jour :");
            Console.WriteLine($"{updatedAuthentification.Email} {updatedAuthentification.Password}");
        }

        [Test]
        public void DeleteAuthentification_WhenAuthentificationExists_DeletesAuthentification()
        {
            int idAuthentificationToDelete = 9;

            _authenticationService.DeleteAuthentification(idAuthentificationToDelete);

            // Expecting an exception to be thrown
            var ex = Assert.Throws<Exception>(() => _authenticationService.GetAuthentificationById(idAuthentificationToDelete));

            Assert.That(ex.Message, Is.EqualTo($"Une erreur est survenue lors de la récupération de l'authentification."));

            Console.WriteLine($"Le test DeleteAuthentification_WhenAuthentificationExists_DeletesAuthentification a réussi !");
            Console.WriteLine($"Authentification avec ID {idAuthentificationToDelete} a été supprimée.");
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

