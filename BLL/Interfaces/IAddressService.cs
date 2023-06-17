using System.Collections.Generic;
using DATA.DTO;

namespace BLL.Services
{
    public interface IAddressService
    {
        AddressDto GetAddressById(int addressId);
        List<AddressDto> GetAllAddresses();
        void CreateAddress(AddressDto addressDto);
        void UpdateAddress(AddressDto addressDto);
        void DeleteAddress(int addressId);
    }
}
