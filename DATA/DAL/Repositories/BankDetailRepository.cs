using DATA.DAL.Context;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IBankDetailRepository
    {
        BankDetail GetBankDetailById(int id);
        List<BankDetail> GetAllBankDetails();
        BankDetail CreateBankDetail(BankDetail bankDetail);
        BankDetail UpdateBankDetail(BankDetail bankDetail);
        void DeleteBankDetail(BankDetail bankDetail);
    }

    public class BankDetailRepository : IBankDetailRepository
    {
        private readonly PlantItContext _dbContext;

        public BankDetailRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BankDetail GetBankDetailById(int id)
        {
            return _dbContext.BankDetails.Find(id);
        }

        public List<BankDetail> GetAllBankDetails()
        {
            return _dbContext.BankDetails.ToList();
        }

        public BankDetail CreateBankDetail(BankDetail bankDetail)
        {
            _dbContext.BankDetails.Add(bankDetail);
            _dbContext.SaveChanges();
            return bankDetail;
        }

        public BankDetail UpdateBankDetail(BankDetail bankDetail)
        {
            _dbContext.BankDetails.Update(bankDetail);
            _dbContext.SaveChanges();
            return bankDetail;
        }

        public void DeleteBankDetail(BankDetail bankDetail)
        {
            _dbContext.BankDetails.Remove(bankDetail);
            _dbContext.SaveChanges();
        }
    }
}
