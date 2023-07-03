using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Services
{
    public interface IPlantService
    {
        PlantDto GetPlantById(int plantId);
        List<PlantDto> GetAllPlants();
        Plant CreatePlant(PlantDto plantDto);
        PlantDto UpdatePlant(PlantDto plantDto);
        void DeletePlant(int plantId);
    }
}
