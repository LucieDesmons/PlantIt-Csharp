using DATA.DAL.Context;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IMaintenanceRepository
    {
        Maintenance GetMaintenanceById(int id);
        List<Maintenance> GetAllMaintenances();
        Maintenance CreateMaintenance(Maintenance maintenance);
        Maintenance UpdateMaintenance(Maintenance maintenance);
        void DeleteMaintenance(Maintenance maintenance);
    }

    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly PlantItContext _dbContext;

        public MaintenanceRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Maintenance GetMaintenanceById(int id)
        {
            return _dbContext.Maintenances.Find(id);
        }

        public List<Maintenance> GetAllMaintenances()
        {
            return _dbContext.Maintenances.ToList();
        }

        public Maintenance CreateMaintenance(Maintenance maintenance)
        {
            _dbContext.Maintenances.Add(maintenance);
            _dbContext.SaveChanges();
            return maintenance;
        }

        public Maintenance UpdateMaintenance(Maintenance maintenance)
        {
            _dbContext.Maintenances.Update(maintenance);
            _dbContext.SaveChanges();
            return maintenance;
        }

        public void DeleteMaintenance(Maintenance maintenance)
        {
            _dbContext.Maintenances.Remove(maintenance);
            _dbContext.SaveChanges();
        }
    }
}
