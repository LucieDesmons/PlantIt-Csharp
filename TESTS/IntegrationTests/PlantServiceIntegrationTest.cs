using BLL.Services;
using DATA.DAL.Context;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace TESTS.IntegrationTests
{
    public class PlantServiceIntegrationTest
    {

        private PlantItContext _dbContext;
        private IPlantRepository _plantRepository;
        private IPlantService _plantService;

        [SetUp]
        public void Setup()
        {
            _dbContext = new PlantItContext();
            _plantRepository = new PlantRepository(_dbContext);
            _plantService = new PlantService(_plantRepository);
        }

        [Test]
        public void GetPlantById_WhenPlantExists_ReturnsCorrectPlant()
        {
            int idPlant = 8;

            var result = _plantService.GetPlantById(idPlant);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IdPlant, Is.EqualTo(idPlant));

            Console.WriteLine("Le test GetAuthenticationById_WhenAuthenticationExists_ReturnsAuthenticationDto a réussi !");
            Console.WriteLine("Plante reçue :");
            Console.WriteLine($"{result.IdPlant} {result.Name}");
        }

        [Test]
        public void GetAllPlants_ReturnsListOfPlants()
        {
            // Act
            var result = _plantService.GetAllPlants();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<PlantDto>>());
            Assert.That(result.Count, Is.GreaterThan(0));

            Console.WriteLine("Le test GetAllPlants_ReturnsListOfPlants() a réussi !");
            Console.WriteLine("Liste des plantes :");

            foreach (var plant in result)
            {
                Console.WriteLine($"{plant.IdPlant} {plant.Name}");
            }
        }

        [Test]
        public void CreatePlant_WhenPlantDtoIsProvided_CreatesPlantInDatabase()
        {
            // Arrange
            var plantDto = new PlantDto
            {
                Name = "Test Plant",
                PlacePlant = "Living Room",
                Container = "Pot",
                Humidity = 70,
                Clarity = 80,
                IdUser = 1,
                IdPlantReference = 5
            };

            // Act
            var createdPlant = _plantService.CreatePlant(plantDto);

            // Assert
            Assert.That(createdPlant, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createdPlant.Name, Is.EqualTo(plantDto.Name));
                Assert.That(createdPlant.PlacePlant, Is.EqualTo(plantDto.PlacePlant));
                Assert.That(createdPlant.Container, Is.EqualTo(plantDto.Container));
                Assert.That(createdPlant.Humidity, Is.EqualTo(plantDto.Humidity));
                Assert.That(createdPlant.Clarity, Is.EqualTo(plantDto.Clarity));                
                Assert.That(createdPlant.IdUser, Is.EqualTo(plantDto.IdUser));                
                Assert.That(createdPlant.IdPlantReference, Is.EqualTo(plantDto.IdPlantReference));

            });

            // Verify that the plant was actually added to the database by retrieving it by ID
            var retrievedPlant = _plantRepository.GetPlantById(createdPlant.IdPlant);
            Assert.IsNotNull(retrievedPlant);
            Assert.That(retrievedPlant.IdPlant, Is.EqualTo(createdPlant.IdPlant));

            Console.WriteLine($"Le test CreatePlant_WhenPlantDtoIsProvided_CreatesPlantInDatabase a réussi !");
            Console.WriteLine($"Plante avec ID {createdPlant.IdPlant} a été créée.");
        }

        [Test]
        public void DeletePlant_ShouldDeletePlant_WhenPlantIdExists()
        {
            // Act
            _plantService.DeletePlant(10);

            // Assert
            var deletedPlant = _dbContext.Plants.Find(10);
            Assert.That(deletedPlant, Is.Null);
        }
    }
}

