using BLL.Mappers;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace BLL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public AddressDto GetAddressById(int addressId)
        {
            try
            {
                var address = _addressRepository.GetAddressById(addressId);
                if (address == null)
                {
                    throw new Exception($"Adresse avec l'ID {addressId} non trouvée.");
                }
                return AddressMapper.MapToDto(address);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la récupération de l'adresse.", ex);
            }
        }

        public List<AddressDto> GetAllAddresses()
        {
            try
            {
                var addresses = _addressRepository.GetAllAddresses();
                return addresses.Select(address => AddressMapper.MapToDto(address)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la récupération des adresses.", ex);
            }
        }

        public AddressDto CreateAddress(AddressDto addressDto)
        {
            try
            {
                var address = AddressMapper.MapToEntity(addressDto);
                var createdAddress = _addressRepository.CreateAddress(address);
                return AddressMapper.MapToDto(createdAddress);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la création de l'adresse.", ex);
            }
        }

        public AddressDto UpdateAddress(AddressDto addressDto)
        {
            try
            {
                var existingAddress = _addressRepository.GetAddressById(addressDto.IdAddress);
                if (existingAddress == null)
                {
                    throw new Exception($"Adresse avec l'ID {addressDto.IdAddress} non trouvée.");
                }

                var updatedAddress = AddressMapper.MapToEntity(addressDto);
                updatedAddress = _addressRepository.UpdateAddress(updatedAddress);
                return AddressMapper.MapToDto(updatedAddress);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la mise à jour de l'adresse.", ex);
            }
        }

        public void DeleteAddress(int addressId)
        {
            try
            {
                var address = _addressRepository.GetAddressById(addressId);
                if (address == null)
                {
                    throw new Exception($"Adresse avec l'ID {addressId} non trouvée.");
                }

                _addressRepository.DeleteAddress(address);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la suppression de l'adresse.", ex);
            }
        }
    }
}
