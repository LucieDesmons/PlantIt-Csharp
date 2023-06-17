using DATA.DAL.DbContextt;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IAddressRepository
    {
        Address GetAddressById(int addressId);

        List<Address> GetAllAddresses();

        Address CreateAddress(Address address);

        Address UpdateAddress(Address address);

        void DeleteAddress(Address address);
    }

    public class AddressRepository : IAddressRepository
    {
        private readonly PlantItContext _dbContext;

        public AddressRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Address GetAddressById(int addressId)
        {
            return _dbContext.Addresses.Find(addressId);
        }

        public List<Address> GetAllAddresses()
        {
            return _dbContext.Addresses.ToList();
        }

        public Address CreateAddress(Address address)
        {
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
            return address;
        }

        public Address UpdateAddress(Address address)
        {
            _dbContext.Addresses.Update(address);
            _dbContext.SaveChanges();
            return address;
        }

        public void DeleteAddress(Address address)
        {
            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();
        }
    }
}
