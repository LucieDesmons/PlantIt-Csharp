using DATA.DAL.Context;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IAuthenticationRepository
    {
        Authentication GetAuthenticationById(int id);
        List<Authentication> GetAllAuthentications();
        Authentication GetAuthenticationByEmail(string email);
        Authentication CreateAuthentication(Authentication authentication);
        Authentication UpdateAuthentication(Authentication authentication);
        void DeleteAuthentication(Authentication authentication);
    }

    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly PlantItContext _dbContext;

        public AuthenticationRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Authentication GetAuthenticationById(int id)
        {
            return _dbContext.Authentications.Find(id);
        }

        public List<Authentication> GetAllAuthentications()
        {
            return _dbContext.Authentications.ToList();
        }

        public Authentication GetAuthenticationByEmail(string email)
        {
                return _dbContext.Authentications.FirstOrDefault(a => a.Email == email);
        }

        public Authentication CreateAuthentication(Authentication authentication)
        {
            _dbContext.Authentications.Add(authentication);
            _dbContext.SaveChanges();
            return authentication;
        }

        public Authentication UpdateAuthentication(Authentication authentication)
        {
            _dbContext.Authentications.Update(authentication);
            _dbContext.SaveChanges();
            return authentication;
        }

        public void DeleteAuthentication(Authentication authentication)
        {
            _dbContext.Authentications.Remove(authentication);
            _dbContext.SaveChanges();
        }
    }
}
