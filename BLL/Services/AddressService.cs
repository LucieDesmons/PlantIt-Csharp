using System;
using System.Collections.Generic;
using DATA.DAL.Entities;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace BLL.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public AddressDto GetAddressById(int addressId)
        {
            Address address = _addressRepository.GetAddressById(addressId);
            return AddressMapper.MapToDto(address);
        }

        public List<AddressDto> GetAllAddresses()
        {
            List<Address> addresses = _addressRepository.GetAllAddresses();
            return AddressMapper.MapToDtoList(addresses);
        }

        public AddressDto CreateAddress(AddressDto addressDto)
        {
            Address address = AddressMapper.MapToEntity(addressDto);
            address = _addressRepository.CreateAddress(address);
            return AddressMapper.MapToDto(address);
        }

        public AddressDto UpdateAddress(AddressDto addressDto)
        {
            Address existingAddress = _addressRepository.GetAddressById(addressDto.IdAddress);

            if (existingAddress == null)
            {
                throw new Exception("Address not found");
            }

            Address updatedAddress = AddressMapper.MapToEntity(addressDto);
            updatedAddress = _addressRepository.UpdateAddress(updatedAddress);
            return AddressMapper.MapToDto(updatedAddress);
        }

        public void DeleteAddress(int addressId)
        {
            Address existingAddress = _addressRepository.GetAddressById(addressId);

            if (existingAddress == null)
            {
                throw new Exception("Address not found");
            }

            _addressRepository.DeleteAddress(existingAddress);
        }
    }
}
