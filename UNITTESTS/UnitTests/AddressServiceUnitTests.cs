using BLL.Mappers;
using BLL.Services;
using DATA.DAL.DbContextt;
using DATA.DAL.Entities;
using DATA.DAL.Repositories;
using DATA.DTO;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UNITTESTS.UnitTests
{
    [TestFixture]
    public class AddressServiceUnitTests
    {
        private PlantItContext _dbContext;
        private IAddressRepository _addressRepository;
        private AddressService _addressService;

        [SetUp]
        public void Setup()
        {
            _dbContext = new PlantItContext();
            _addressRepository = Mock.Of<IAddressRepository>();
            _addressService = new AddressService(_addressRepository);
        }

        [Test]
        public void MockGetAddressById_ExistingAddressId_ReturnsAddressDto()
        {
            int addressId = 1;
            var expectedAddress = new Address
            {
                IdAddress = addressId,
                Number = 1195,
                PostalCode = "69280",
                Way = "Avenue Marcel Mérieux",
                AdditionalAddress = null,
                Town = "Marcy-l'Etoile"
            };
            Mock.Get(_addressRepository)
                .Setup(r => r.GetAddressById(addressId))
                .Returns(expectedAddress);

            var result = _addressService.GetAddressById(addressId);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.IdAddress, Is.EqualTo(expectedAddress.IdAddress));
                Assert.That(result.Number, Is.EqualTo(expectedAddress.Number));
                Assert.That(result.PostalCode, Is.EqualTo(expectedAddress.PostalCode));
                Assert.That(result.Way, Is.EqualTo(expectedAddress.Way));
                Assert.That(result.AdditionalAddress, Is.EqualTo(expectedAddress.AdditionalAddress));
                Assert.That(result.Town, Is.EqualTo(expectedAddress.Town));
            });

            Console.WriteLine("Le test GetAddressById_ExistingAddressId_ReturnsAddressDto a réussi !");
            Console.WriteLine("Adresse attendue :");
            Console.WriteLine($"{expectedAddress.Number} {expectedAddress.Way}, {expectedAddress.PostalCode} {expectedAddress.Town}");
            Console.WriteLine("Adresse reçue :");
            Console.WriteLine($"{result.Number} {result.Way}, {result.PostalCode} {result.Town}");
        }

        [Test]
        public void MockGetAllAddresses_ExistingAddresses_ReturnsListOfAddressDto()
        {
            // Arrange
            var expectedAddresses = new List<Address>
            {
                new Address
                {
                    IdAddress = 1,
                    Number = 1195,
                    PostalCode = "69280",
                    Way = "Avenue Marcel Mérieux",
                    AdditionalAddress = null,
                    Town = "Marcy-l'Etoile"
                },
                new Address
                {
                    IdAddress = 2,
                    Number = 230,
                    PostalCode = "62490",
                    Way = "Rue de Bellonne",
                    AdditionalAddress = null,
                    Town = "Noyelles-sous-Bellonne"
                }
            };

            Mock.Get(_addressRepository)
                .Setup(r => r.GetAllAddresses())
                .Returns(expectedAddresses);

            // Act
            var result = _addressService.GetAllAddresses();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(expectedAddresses.Count));

            for (int i = 0; i < expectedAddresses.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(result[i].IdAddress, Is.EqualTo(expectedAddresses[i].IdAddress));
                    Assert.That(result[i].Number, Is.EqualTo(expectedAddresses[i].Number));
                    Assert.That(result[i].PostalCode, Is.EqualTo(expectedAddresses[i].PostalCode));
                    Assert.That(result[i].Way, Is.EqualTo(expectedAddresses[i].Way));
                    Assert.That(result[i].AdditionalAddress, Is.EqualTo(expectedAddresses[i].AdditionalAddress));
                    Assert.That(result[i].Town, Is.EqualTo(expectedAddresses[i].Town));
                });
            }

            Console.WriteLine("Le test GetAllAddresses_ExistingAddresses_ReturnsListOfAddressDto a réussi !");
            Console.WriteLine("Adresses attendues :");

            foreach (var expectedAddress in expectedAddresses)
            {
                Console.WriteLine($"{expectedAddress.Number} {expectedAddress.Way}, {expectedAddress.PostalCode} {expectedAddress.Town}");
            }

            Console.WriteLine("Adresses reçues :");

            foreach (var addressDto in result)
            {
                Console.WriteLine($"{addressDto.Number} {addressDto.Way}, {addressDto.PostalCode} {addressDto.Town}");
            }
        }

        [Test]
        public void MockUpdateAddress_ExistingAddressDto_ReturnsUpdatedAddressDto()
        {
            // Configurer le mock
            int existingAddressId = 4;
            var initialAddress = new AddressDto
            {
                IdAddress = existingAddressId,
                Number = 1,
                PostalCode = "12345",
                Way = "Old St",
                AdditionalAddress = "1st Floor",
                Town = "Old Town"
            };

            var mockAddressRepository = new Mock<IAddressRepository>(); // Utilisation de Moq pour créer un mock
            mockAddressRepository.Setup(repo => repo.GetAddressById(existingAddressId)).Returns(AddressMapper.MapToEntity(initialAddress));
            mockAddressRepository.Setup(repo => repo.UpdateAddress(It.IsAny<Address>())).Returns<Address>((updatedAddress) => AddressMapper.MapToEntity(AddressMapper.MapToDto(updatedAddress)));

            // Utiliser le mock au lieu du véritable repository
            var addressService = new AddressService(mockAddressRepository.Object);

            // Copie de l'adresse existante avec de nouvelles valeurs
            var existingAddress = addressService.GetAddressById(existingAddressId);
            existingAddress.Number = 96;
            existingAddress.PostalCode = "67890";
            existingAddress.Way = "Elm St";
            existingAddress.AdditionalAddress = "RDC";
            existingAddress.Town = "Rue des chameaux";

            // Mise à jour de l'adresse
            var updatedAddress = addressService.UpdateAddress(existingAddress);

            // Assertions
            Assert.That(updatedAddress, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(updatedAddress.IdAddress, Is.EqualTo(existingAddress.IdAddress));
                Assert.That(updatedAddress.Number, Is.EqualTo(existingAddress.Number));
                Assert.That(updatedAddress.PostalCode, Is.EqualTo(existingAddress.PostalCode));
                Assert.That(updatedAddress.Way, Is.EqualTo(existingAddress.Way));
                Assert.That(updatedAddress.AdditionalAddress, Is.EqualTo(existingAddress.AdditionalAddress));
                Assert.That(updatedAddress.Town, Is.EqualTo(existingAddress.Town));
            });

            Console.WriteLine("Le test UpdateAddress_ExistingAddressDto_ReturnsUpdatedAddressDto a réussi !");
            Console.WriteLine("Adresse mise à jour :");
            Console.WriteLine($"{updatedAddress.Number} {updatedAddress.Way}, {updatedAddress.AdditionalAddress}, {updatedAddress.PostalCode} {updatedAddress.Town}");
            Console.WriteLine("Adresse attendue :");
            Console.WriteLine($"{existingAddress.Number} {existingAddress.Way}, {existingAddress.AdditionalAddress}, {existingAddress.PostalCode} {existingAddress.Town}");
        }

        [Test]
        public void MockDeleteAddress_ExistingAddressId_AddressIsDeleted()
        {
            // Arrange
            int addressIdToDelete = 1;

            var mockAddress = new Address
            {
                IdAddress = addressIdToDelete
            };

            var mockAddressRepository = new Mock<IAddressRepository>();
            mockAddressRepository.Setup(repo => repo.GetAddressById(addressIdToDelete)).Returns(mockAddress);
            mockAddressRepository.Setup(repo => repo.DeleteAddress(mockAddress)).Callback(() => mockAddressRepository.Setup(repo => repo.GetAddressById(addressIdToDelete)).Returns((Address)null));

            var addressService = new AddressService(mockAddressRepository.Object);

            // Act
            addressService.DeleteAddress(addressIdToDelete);

            // Assert
            var deletedAddress = mockAddressRepository.Object.GetAddressById(addressIdToDelete);
            Assert.That(deletedAddress, Is.Null);

            Console.WriteLine("Le test MockDeleteAddress_ExistingAddressId_AddressIsDeleted a réussi !");
            Console.WriteLine("L'adresse a bien été suprimée !");
        }

    }
}

