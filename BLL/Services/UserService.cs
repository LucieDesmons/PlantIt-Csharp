using BLL.Mappers;
using DATA.DAL.Context;
using DATA.DAL.Entities;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto GetUserById(int userId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);
                if (user == null)
                {
                    throw new Exception($"Utilisateur avec l'ID {userId} non trouvé.");
                }
                return UserMapper.MapToDto(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la récupération de l'utilisateur.", ex);
            }
        }

        public List<UserDto> GetAllUsers()
        {
            try
            {
                var users = _userRepository.GetAllUsers();
                return users.Select(user => UserMapper.MapToDto(user)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la récupération des utilisateurs.", ex);
            }
        }

        public UserDto CreateUser(UserDto userDto)
        {
            try
            {
                Address address = AddressMapper.MapToEntity(userDto.Address);
                Authentication authentication = AuthenticationMapper.MapToEntity(userDto.Authentication);

                userDto.Authentication.IdAuthentication = authentication.IdAuthentication;
                userDto.Address.IdAddress = address.IdAddress;

                var user = UserMapper.MapToEntity(userDto);

                var createdUser = _userRepository.CreateUser(user);

                return UserMapper.MapToDto(createdUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la création de l'utilisateur.", ex);
            }
        }

      /*  public User CreateCustomer(UserDto userDto)
        {
            var userTypeDto = new UserTypeDto
            {
                IdUserType = 3
            };
            userDto.UserType = userTypeDto;

            var user = CreateUser(userDto);

            return _userRepository.UpdateUser(user);
        } */

        public User CreateBotanist(UserDto userDto)
        {
            var userTypeDTO = new UserTypeDto
            {
                IdUserType = 2
            };
            userDto.UserType = userTypeDTO;

            var user = CreateUser(userDto); 

            user.Degree = userDto.Degree;
            user.Specialization = userDto.Specialization;

            return _userRepository.UpdateUser(UserMapper.MapToEntity(user));
        }

        public UserDto UpdateUser(UserDto userDto)
        {
            try
            {
                var existingUser = _userRepository.GetUserById(userDto.IdUser);
                if (existingUser == null)
                {
                    throw new Exception($"Utilisateur avec l'ID {userDto.IdUser} non trouvé.");
                }

                var updatedUser = UserMapper.MapToEntity(userDto);
                updatedUser = _userRepository.UpdateUser(updatedUser);
                return UserMapper.MapToDto(updatedUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la mise à jour de l'utilisateur.", ex);
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);
                if (user == null)
                {
                    throw new Exception($"Utilisateur avec l'ID {userId} non trouvé.");
                }

                _userRepository.DeleteUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la suppression de l'utilisateur.", ex);
            }
        }
    }
}
