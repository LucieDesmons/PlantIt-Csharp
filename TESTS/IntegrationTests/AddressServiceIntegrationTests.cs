using BLL.Services;
using DATA.DAL.Context;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace TESTS.IntegrationTests
{
    [TestFixture]
    public class AddressServiceIntegrationTests
    {
        private PlantItContext _dbContext;
        private IAddressRepository _addressRepository;
        private AddressService _addressService;

        [SetUp]
        public void Setup()
        {
            _dbContext = new PlantItContext();
            _addressRepository = new AddressRepository(_dbContext);
            _addressService = new AddressService(_addressRepository);
        }

        [Test]
        public void GetAddressById_ExistingAddressId_ReturnsAddressDto()
        {
            int existingAddressId = 1;
            var result = _addressService.GetAddressById(existingAddressId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IdAddress, Is.EqualTo(existingAddressId));

            Console.WriteLine("Le test GetAddressById_ExistingAddressId_ReturnsAddressDto a réussi !");
            Console.WriteLine("Adresse récupérée :");
            Console.WriteLine($"{result.Number} {result.Way}, {result.PostalCode} {result.Town}");
        }

        [Test]
        public void GetAllAddresses_ReturnsListOfAddresses()
        {
            // Act
            var result = _addressService.GetAllAddresses();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<AddressDto>>());
            Assert.That(result.Count, Is.GreaterThan(0));

            Console.WriteLine("Le test GetAllAddresses_ReturnsListOfAddresses a réussi !");
            Console.WriteLine("Liste des adresses :");

            foreach (var address in result)
            {
                Console.WriteLine($"{address.Number} {address.Way}, {address.PostalCode} {address.Town}");
            }
        }

        [Test]
        public void UpdateAddress_ExistingAddressDto_ReturnsUpdatedAddressDto()
        {
            int existingAddressId = 11;
            var existingAddress = _addressService.GetAddressById(existingAddressId);

            existingAddress.Number = 96;
            existingAddress.PostalCode = "67890";
            existingAddress.Way = "Elm St";
            existingAddress.AdditionalAddress = "RDC";
            existingAddress.Town = "Rue des chameaux";

            var updatedAddress = _addressService.UpdateAddress(existingAddress);

            var result = _addressService.GetAddressById(existingAddressId);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.IdAddress, Is.EqualTo(existingAddress.IdAddress));
                Assert.That(result.Number, Is.EqualTo(existingAddress.Number));
                Assert.That(result.PostalCode, Is.EqualTo(existingAddress.PostalCode));
                Assert.That(result.Way, Is.EqualTo(existingAddress.Way));
                Assert.That(result.AdditionalAddress, Is.EqualTo(existingAddress.AdditionalAddress));
                Assert.That(result.Town, Is.EqualTo(existingAddress.Town));
            });

            Console.WriteLine("Le test UpdateAddress_ExistingAddressDto_ReturnsUpdatedAddressDto a réussi !");
            Console.WriteLine("Adresse mise à jour :");
            Console.WriteLine($"{updatedAddress.Number} {updatedAddress.Way}, {updatedAddress.AdditionalAddress}, {updatedAddress.PostalCode} {updatedAddress.Town}");
        }

        [Test]
        public void DeleteAddress_ExistingAddressId_AddressIsDeleted()
        {
            int existingAddressId = 13;

            _addressService.DeleteAddress(existingAddressId);

            var ex = Assert.Throws<Exception>(() => _addressService.GetAddressById(existingAddressId));

            Assert.That(ex.Message, Is.EqualTo($"Une erreur est survenue lors de la récupération de l'adresse."));

            Console.WriteLine("Le test DeleteAddress_ExistingAddressId_AddressIsDeleted a réussi !");
            Console.WriteLine($"L'adresse avec ID {existingAddressId} a bien été suprimée !");
        }
    }
}