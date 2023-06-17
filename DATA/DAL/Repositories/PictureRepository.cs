using DATA.DAL.DbContextt;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IPictureRepository
    {
        Picture GetPictureById(int id);
        List<Picture> GetAllPictures();
        Picture CreatePicture(Picture picture);
        Picture UpdatePicture(Picture picture);
        void DeletePicture(Picture picture);
    }

    public class PictureRepository : IPictureRepository
    {
        private readonly PlantItContext _dbContext;

        public PictureRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Picture GetPictureById(int id)
        {
            return _dbContext.Pictures.Find(id);
        }

        public List<Picture> GetAllPictures()
        {
            return _dbContext.Pictures.ToList();
        }

        public Picture CreatePicture(Picture picture)
        {
            _dbContext.Pictures.Add(picture);
            _dbContext.SaveChanges();
            return picture;
        }

        public Picture UpdatePicture(Picture picture)
        {
            _dbContext.Pictures.Update(picture);
            _dbContext.SaveChanges();
            return picture;
        }

        public void DeletePicture(Picture picture)
        {
            _dbContext.Pictures.Remove(picture);
            _dbContext.SaveChanges();
        }
    }
}
