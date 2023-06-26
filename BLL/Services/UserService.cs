using BLL.Mappers;
using DATA.DAL.DbContextt;
using DATA.DAL.Entities;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace BLL.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PlantItContext _dbContext;
        private readonly AddressService _addressService;
        private readonly AuthenticationService _authenticationService;

        public UserService(IUserRepository userRepository, AddressService addressService, AuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _dbContext = new PlantItContext();
            _addressService = addressService;
            _authenticationService = authenticationService;

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

        public User CreateUser(UserDto userDto)
        {
            try
            {
                // Créer les entités dépendantes (Address et Authentification)
                AddressDto addressDto = _addressService.CreateAddress(userDto.Address);
                AuthentificationDto authentificationDto = _authenticationService.CreateAuthentification(userDto.Authentification);

                // Imprimez les identifiants pour vérifier qu'ils sont corrects
                Console.WriteLine($"ID de l'adresse après création: {addressDto.IdAddress}");
                Console.WriteLine($"ID de l'authentification Dto: {authentificationDto.IdAuthentification}");

                // Vérifiez que les identifiants sont présents
                if (addressDto.IdAddress == 0 || authentificationDto.IdAuthentification == 0)
                {
                    throw new Exception("L'adresse ou l'authentification n'a pas été correctement créée.");
                }

                // Assigner les entités créées à l'utilisateur DTO
                userDto.Address = addressDto;
                userDto.Authentification = authentificationDto;

                // Mapper l'utilisateur
                var user = UserMapper.MapToEntity(userDto);


                Console.WriteLine($"ID de l'authentification entité: {user.IdAuthentification}");

                // Ajouter l'utilisateur à la base de données
                var createdUser = _userRepository.CreateUser(user);

                Console.WriteLine($"ID de l'authentification après création: {createdUser.IdAuthentification}");

                return createdUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la création de l'utilisateur.", ex);
            }
        }




        public User CreateCustomer(UserDto userDto)
        {
            var userTypeDto = new UserTypeDto
            {
                IdUserType = 3
            };
            userDto.UserType = userTypeDto;

            var user = CreateUser(userDto);

            return _userRepository.UpdateUser(user);
        }

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

            return _userRepository.UpdateUser(user);
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
