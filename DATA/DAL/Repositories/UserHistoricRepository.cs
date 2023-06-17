using DATA.DAL.DbContextt;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IUserHistoricRepository
    {
        UserHistoric GetUserHistoricById(int id);
        List<UserHistoric> GetAllUserHistorics();
        UserHistoric CreateUserHistoric(UserHistoric userHistoric);
        UserHistoric UpdateUserHistoric(UserHistoric userHistoric);
        void DeleteUserHistoric(UserHistoric userHistoric);
    }

    public class UserHistoricRepository : IUserHistoricRepository
    {
        private readonly PlantItContext _dbContext;

        public UserHistoricRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserHistoric GetUserHistoricById(int id)
        {
            return _dbContext.UserHistorics.Find(id);
        }

        public List<UserHistoric> GetAllUserHistorics()
        {
            return _dbContext.UserHistorics.ToList();
        }

        public UserHistoric CreateUserHistoric(UserHistoric userHistoric)
        {
            _dbContext.UserHistorics.Add(userHistoric);
            _dbContext.SaveChanges();
            return userHistoric;
        }

        public UserHistoric UpdateUserHistoric(UserHistoric userHistoric)
        {
            _dbContext.UserHistorics.Update(userHistoric);
            _dbContext.SaveChanges();
            return userHistoric;
        }

        public void DeleteUserHistoric(UserHistoric userHistoric)
        {
            _dbContext.UserHistorics.Remove(userHistoric);
            _dbContext.SaveChanges();
        }
    }
}
