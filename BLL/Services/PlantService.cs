using BLL.Mappers;
using DATA.DAL.Context;
using DATA.DAL.Entities;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace BLL.Services
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;

        public PlantService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public PlantDto GetPlantById(int plantId)
        {
            try
            {
                var plant = _plantRepository.GetPlantById(plantId);
                if (plant == null)
                {
                    throw new Exception($"Plante avec l'ID {plantId} non trouvée.");
                }
                return PlantMapper.MapToDto(plant);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la récupération de la plante.", ex);
            }
        }

        public List<PlantDto> GetAllPlants()
        {
            try
            {
                var plants = _plantRepository.GetAllPlants();
                return plants.Select(plant => PlantMapper.MapToDto(plant)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la récupération des plantes.", ex);
            }
        }

        public Plant CreatePlant(PlantDto plantDto)
        {
            try
            {
                var plant = PlantMapper.MapToEntity(plantDto);
                var createdPlant = _plantRepository.CreatePlant(plant);
                return createdPlant;
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la création de la plante.", ex);
            }
        }

        public PlantDto UpdatePlant(PlantDto plantDto)
        {
            try
            {
                var existingPlant = _plantRepository.GetPlantById(plantDto.IdPlant);
                if (existingPlant == null)
                {
                    throw new Exception($"Plante avec l'ID {plantDto.IdPlant} non trouvée.");
                }

                var updatedPlant = PlantMapper.MapToEntity(plantDto);
                updatedPlant = _plantRepository.UpdatePlant(updatedPlant);
                return PlantMapper.MapToDto(updatedPlant);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la mise à jour de la plante.", ex);
            }
        }

        public void DeletePlant(int plantId)
        {
            try
            {
                var plant = _plantRepository.GetPlantById(plantId);
                if (plant == null)
                {
                    throw new Exception($"Plante avec l'ID {plantId} non trouvée.");
                }

                _plantRepository.DeletePlant(plant);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la suppression de la plante.", ex);
            }
        }
    }
}
