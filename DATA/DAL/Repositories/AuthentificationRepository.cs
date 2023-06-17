using DATA.DAL.DbContextt;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IAuthentificationRepository
    {
        Authentification GetAuthentificationById(int id);
        List<Authentification> GetAllAuthentifications();
        Authentification CreateAuthentification(Authentification authentification);
        Authentification UpdateAuthentification(Authentification authentification);
        void DeleteAuthentification(Authentification authentification);
    }

    public class AuthentificationRepository : IAuthentificationRepository
    {
        private readonly PlantItContext _dbContext;

        public AuthentificationRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Authentification GetAuthentificationById(int id)
        {
            return _dbContext.Authentifications.Find(id);
        }

        public List<Authentification> GetAllAuthentifications()
        {
            return _dbContext.Authentifications.ToList();
        }

        public Authentification CreateAuthentification(Authentification authentification)
        {
            _dbContext.Authentifications.Add(authentification);
            _dbContext.SaveChanges();
            return authentification;
        }

        public Authentification UpdateAuthentification(Authentification authentification)
        {
            _dbContext.Authentifications.Update(authentification);
            _dbContext.SaveChanges();
            return authentification;
        }

        public void DeleteAuthentification(Authentification authentification)
        {
            _dbContext.Authentifications.Remove(authentification);
            _dbContext.SaveChanges();
        }
    }
}
