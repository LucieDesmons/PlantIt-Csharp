using DATA.DAL.Context;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IUserTypeRepository
    {
        UserType GetUserTypeById(int id);
        List<UserType> GetAllUserTypes();
        UserType CreateUserType(UserType userType);
        UserType UpdateUserType(UserType userType);
        void DeleteUserType(UserType userType);
    }

    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly PlantItContext _dbContext;

        public UserTypeRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserType GetUserTypeById(int id)
        {
            return _dbContext.UserTypes.Find(id);
        }

        public List<UserType> GetAllUserTypes()
        {
            return _dbContext.UserTypes.ToList();
        }

        public UserType CreateUserType(UserType userType)
        {
            _dbContext.UserTypes.Add(userType);
            _dbContext.SaveChanges();
            return userType;
        }

        public UserType UpdateUserType(UserType userType)
        {
            _dbContext.UserTypes.Update(userType);
            _dbContext.SaveChanges();
            return userType;
        }

        public void DeleteUserType(UserType userType)
        {
            _dbContext.UserTypes.Remove(userType);
            _dbContext.SaveChanges();
        }
    }
}
