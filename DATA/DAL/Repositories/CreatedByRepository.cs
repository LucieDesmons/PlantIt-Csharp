using DATA.DAL.Context;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface ICreatedByRepository
    {
        CreatedBy GetCreatedByById(int id);
        List<CreatedBy> GetAllCreatedBy();
        CreatedBy CreateCreatedBy(CreatedBy createdBy);
        CreatedBy UpdateCreatedBy(CreatedBy createdBy);
        void DeleteCreatedBy(CreatedBy createdBy);
    }

    public class CreatedByRepository : ICreatedByRepository
    {
        private readonly PlantItContext _dbContext;

        public CreatedByRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CreatedBy GetCreatedByById(int id)
        {
            return _dbContext.CreatedBies.Find(id);
        }

        public List<CreatedBy> GetAllCreatedBy()
        {
            return _dbContext.CreatedBies.ToList();
        }

        public CreatedBy CreateCreatedBy(CreatedBy createdBy)
        {
            _dbContext.CreatedBies.Add(createdBy);
            _dbContext.SaveChanges();
            return createdBy;
        }

        public CreatedBy UpdateCreatedBy(CreatedBy createdBy)
        {
            _dbContext.CreatedBies.Update(createdBy);
            _dbContext.SaveChanges();
            return createdBy;
        }

        public void DeleteCreatedBy(CreatedBy createdBy)
        {
            _dbContext.CreatedBies.Remove(createdBy);
            _dbContext.SaveChanges();
        }
    }
}
