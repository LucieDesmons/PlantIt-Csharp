using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class AddressMapper
    {
        public static AddressDto MapToDto(Address address)
        {
            return new AddressDto
            {
                IdAddress = address.IdAddress,
                Number = address.Number,
                PostalCode = address.PostalCode,
                Way = address.Way,
                AdditionalAddress = address.AdditionalAddress,
                Town = address.Town,
            };
        }

        public static Address MapToEntity(AddressDto addressDto)
        {
            return new Address
            {
              //  IdAddress = addressDto.IdAddress,
                Number = addressDto.Number,
                PostalCode = addressDto.PostalCode,
                Way = addressDto.Way,
                AdditionalAddress = addressDto.AdditionalAddress,
                Town = addressDto.Town,
            };
        }
    }
}
