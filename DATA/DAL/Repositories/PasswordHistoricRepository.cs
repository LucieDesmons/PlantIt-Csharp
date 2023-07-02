using DATA.DAL.Context;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IPasswordHistoricRepository
    {
        PasswordHistoric GetPasswordHistoricById(int id);
        List<PasswordHistoric> GetAllPasswordHistorics();
        PasswordHistoric CreatePasswordHistoric(PasswordHistoric passwordHistoric);
        PasswordHistoric UpdatePasswordHistoric(PasswordHistoric passwordHistoric);
        void DeletePasswordHistoric(PasswordHistoric passwordHistoric);
    }

    public class PasswordHistoricRepository : IPasswordHistoricRepository
    {
        private readonly PlantItContext _dbContext;

        public PasswordHistoricRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PasswordHistoric GetPasswordHistoricById(int id)
        {
            return _dbContext.PasswordHistorics.Find(id);
        }

        public List<PasswordHistoric> GetAllPasswordHistorics()
        {
            return _dbContext.PasswordHistorics.ToList();
        }

        public PasswordHistoric CreatePasswordHistoric(PasswordHistoric passwordHistoric)
        {
            _dbContext.PasswordHistorics.Add(passwordHistoric);
            _dbContext.SaveChanges();
            return passwordHistoric;
        }

        public PasswordHistoric UpdatePasswordHistoric(PasswordHistoric passwordHistoric)
        {
            _dbContext.PasswordHistorics.Update(passwordHistoric);
            _dbContext.SaveChanges();
            return passwordHistoric;
        }

        public void DeletePasswordHistoric(PasswordHistoric passwordHistoric)
        {
            _dbContext.PasswordHistorics.Remove(passwordHistoric);
            _dbContext.SaveChanges();
        }
    }
}
