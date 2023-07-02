using DATA.DAL.Context;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IPlantRepository
    {
        Plant GetPlantById(int id);
        List<Plant> GetAllPlants();
        Plant CreatePlant(Plant plant);
        Plant UpdatePlant(Plant plant);
        void DeletePlant(Plant plant);
    }

    public class PlantRepository : IPlantRepository
    {
        private readonly PlantItContext _dbContext;

        public PlantRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Plant GetPlantById(int id)
        {
            return _dbContext.Plants.Find(id);
        }

        public List<Plant> GetAllPlants()
        {
            return _dbContext.Plants.ToList();
        }

        public Plant CreatePlant(Plant plant)
        {
            _dbContext.Plants.Add(plant);
            _dbContext.SaveChanges();
            return plant;
        }

        public Plant UpdatePlant(Plant plant)
        {
            _dbContext.Plants.Update(plant);
            _dbContext.SaveChanges();
            return plant;
        }

        public void DeletePlant(Plant plant)
        {
            _dbContext.Plants.Remove(plant);
            _dbContext.SaveChanges();
        }
    }
}
