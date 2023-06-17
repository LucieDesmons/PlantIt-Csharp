using DATA.DAL.DbContextt;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IPlantReferenceRepository
    {
        PlantReference GetPlantReferenceById(int id);
        List<PlantReference> GetAllPlantReferences();
        PlantReference CreatePlantReference(PlantReference plantReference);
        PlantReference UpdatePlantReference(PlantReference plantReference);
        void DeletePlantReference(PlantReference plantReference);
    }

    public class PlantReferenceRepository : IPlantReferenceRepository
    {
        private readonly PlantItContext _dbContext;

        public PlantReferenceRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PlantReference GetPlantReferenceById(int id)
        {
            return _dbContext.PlantReferences.Find(id);
        }

        public List<PlantReference> GetAllPlantReferences()
        {
            return _dbContext.PlantReferences.ToList();
        }

        public PlantReference CreatePlantReference(PlantReference plantReference)
        {
            _dbContext.PlantReferences.Add(plantReference);
            _dbContext.SaveChanges();
            return plantReference;
        }

        public PlantReference UpdatePlantReference(PlantReference plantReference)
        {
            _dbContext.PlantReferences.Update(plantReference);
            _dbContext.SaveChanges();
            return plantReference;
        }

        public void DeletePlantReference(PlantReference plantReference)
        {
            _dbContext.PlantReferences.Remove(plantReference);
            _dbContext.SaveChanges();
        }
    }
}
