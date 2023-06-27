using BLL.Interfaces;
using BLL.Mappers;
using DATA.DAL.Repositories;
using DATA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto CreateUser(UserDto userDto)
        {
            try
            {
                var createdUser = _userRepository.CreateUser(UserMapper.MapToEntity(userDto));
                return UserMapper.MapToDto(createdUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la création de l'adresse.", ex);
            }
        }
    }
}
