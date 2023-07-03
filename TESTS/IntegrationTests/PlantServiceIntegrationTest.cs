using BLL.Services;
using DATA.DAL.Context;
using DATA.DAL.Entities;
using DATA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

