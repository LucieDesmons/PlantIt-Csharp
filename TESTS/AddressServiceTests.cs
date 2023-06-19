using BLL.Mappers;
using BLL.Services;
using DATA.DAL.DbContextt;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace TESTS
{
    [TestClass]
    public class AddressServiceTests
    {
        [TestMethod]
        public void GetAddressById_ExistingAddressId_ReturnsAddressDto()
        {
            // Arrange
            int addressId = 1;
            var expectedAddressDto = new AddressDto
            {
                IdAddress = addressId,
                Number = 1195,
                PostalCode = "69280",
                Way = "Avenue Marcel Mérieux",
                AdditionalAddress = null,
                Town = "Marcy-l'Etoile"
            };

            // Create an instance of the PlantItContext
            var dbContext = new PlantItContext();

            // Create an instance of the address repository with the context
            var addressRepository = new AddressRepository(dbContext);

            var addressService = new AddressService(addressRepository);

            // Act
            var result = addressService.GetAddressById(addressId);

            // Assert
            Assert.AreEqual(expectedAddressDto.IdAddress, result.IdAddress);
            Assert.AreEqual(expectedAddressDto.Number, result.Number);
            Assert.AreEqual(expectedAddressDto.PostalCode, result.PostalCode);
            Assert.AreEqual(expectedAddressDto.Way, result.Way);
            Assert.AreEqual(expectedAddressDto.AdditionalAddress, result.AdditionalAddress);
            Assert.AreEqual(expectedAddressDto.Town, result.Town);

            // Output
            Console.WriteLine("Le test GetAddressById_ExistingAddressId_ReturnsAddressDto a réussi !");
            Console.WriteLine("Adresse attendue :");
            Console.WriteLine($"{expectedAddressDto.Number} {expectedAddressDto.Way}, {expectedAddressDto.PostalCode} {expectedAddressDto.Town}");
            Console.WriteLine("Adresse reçue :");
            Console.WriteLine($"{result.Number} {result.Way}, {result.PostalCode} {result.Town}");
            // Pause to display the messages
            Console.ReadKey();

        }
    }
}