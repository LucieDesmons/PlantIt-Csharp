using DATA.DAL.Context;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IPictureReferenceRepository
    {
        PictureReference GetPictureReferenceById(int id);
        List<PictureReference> GetAllPictureReferences();
        PictureReference CreatePictureReference(PictureReference pictureReference);
        PictureReference UpdatePictureReference(PictureReference pictureReference);
        void DeletePictureReference(PictureReference pictureReference);
    }

    public class PictureReferenceRepository : IPictureReferenceRepository
    {
        private readonly PlantItContext _dbContext;

        public PictureReferenceRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PictureReference GetPictureReferenceById(int id)
        {
            return _dbContext.PictureReferences.Find(id);
        }

        public List<PictureReference> GetAllPictureReferences()
        {
            return _dbContext.PictureReferences.ToList();
        }

        public PictureReference CreatePictureReference(PictureReference pictureReference)
        {
            _dbContext.PictureReferences.Add(pictureReference);
            _dbContext.SaveChanges();
            return pictureReference;
        }

        public PictureReference UpdatePictureReference(PictureReference pictureReference)
        {
            _dbContext.PictureReferences.Update(pictureReference);
            _dbContext.SaveChanges();
            return pictureReference;
        }

        public void DeletePictureReference(PictureReference pictureReference)
        {
            _dbContext.PictureReferences.Remove(pictureReference);
            _dbContext.SaveChanges();
        }
    }
}
