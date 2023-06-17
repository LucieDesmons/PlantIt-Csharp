using System.Collections.Generic;
using DATA.DTO;

namespace BLL.Services
{
    public interface IAddressService
    {
        AddressDto GetAddressById(int addressId);
        List<AddressDto> GetAllAddresses();
        AddressDto CreateAddress(AddressDto addressDto);
        AddressDto UpdateAddress(AddressDto addressDto);
        void DeleteAddress(int addressId);
    }
}
