using DATA.DAL.DbContextt;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly PlantItContext _dbContext;

        public UserRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
