using DATA.DAL.DbContextt;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IManageRepository
    {
        Manage GetManageById(int id);
        List<Manage> GetAllManages();
        Manage CreateManage(Manage manage);
        Manage UpdateManage(Manage manage);
        void DeleteManage(Manage manage);
    }

    public class ManageRepository : IManageRepository
    {
        private readonly PlantItContext _dbContext;

        public ManageRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Manage GetManageById(int id)
        {
            return _dbContext.Manages.Find(id);
        }

        public List<Manage> GetAllManages()
        {
            return _dbContext.Manages.ToList();
        }

        public Manage CreateManage(Manage manage)
        {
            _dbContext.Manages.Add(manage);
            _dbContext.SaveChanges();
            return manage;
        }

        public Manage UpdateManage(Manage manage)
        {
            _dbContext.Manages.Update(manage);
            _dbContext.SaveChanges();
            return manage;
        }

        public void DeleteManage(Manage manage)
        {
            _dbContext.Manages.Remove(manage);
            _dbContext.SaveChanges();
        }
    }
}
