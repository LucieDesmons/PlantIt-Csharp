using BLL.Mappers;
using BLL.Services;
using DATA.DAL.Entities;
using DATA.DAL.Context;
using DATA.DAL.Repositories;
using DATA.DTO;

namespace TESTS.IntegrationTests
{
    public class UserServiceIntegrationTests
    {
        private PlantItContext _dbContext;
        private IUserRepository _userRepository;
        private UserService _userService;
        private IUserTypeRepository _userTypeRepository;

        [SetUp]
        public void Setup()
        {
            _dbContext = new PlantItContext();
            _userRepository = new UserRepository(_dbContext);
            _userService = new UserService(_userRepository);
            _userTypeRepository = new UserTypeRepository(_dbContext);
        }

        [Test]
        public void GetAllUsers_ReturnsListOfUsers()
        {
            // Act
            var result = _userService.GetAllUsers();
            
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<UserDto>>());
            Assert.That(result.Count, Is.GreaterThan(0));

            Console.WriteLine("Le test GetAllUsers_ReturnsListOfUsers a réussi !");
            Console.WriteLine("Liste des users :");

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Name} {user.IdAddress} {user.IdAuthentication}");
            }
        }

        [Test]
        public void CreateUser_WhenUserDtoIsProvided_CreatesUserInDatabase()
        {
            // Arrange
            var address = new Address
            {
                Number = 123,
                PostalCode = "12345",
                Way = "Test Way",
                AdditionalAddress = "Test Additional Address",
                Town = "Test Town"
            };

            var timestamp = DateTime.Now.Ticks;
            var email = $"testCreateUser{timestamp}@example.com";
            var password = $"password{timestamp}";

            var authentication = new Authentication
            {
                Email = email,
                Password = password
            };

            var userType = _userTypeRepository.GetUserTypeById(1);

            var userDto = new UserDto
            {
                Name = "TestName",
                FirstName = "TestFirstName",
                Phone = "123456789",
                Degree = "TestDegree",
                Specialization = "TestSpecialization",
                Hobbies = "TestHobbies",
                Address = AddressMapper.MapToDto(address),
                Authentication = AuthenticationMapper.MapToDto(authentication),
                UserType = UserTypeMapper.MapToDto(userType)
            };

            // Act
            var createdUserDto = _userService.CreateUser(userDto);

            // Assert
            Assert.That(createdUserDto, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createdUserDto.Name, Is.EqualTo(userDto.Name));
                Assert.That(createdUserDto.FirstName, Is.EqualTo(userDto.FirstName));
                Assert.That(createdUserDto.Phone, Is.EqualTo(userDto.Phone));
                Assert.That(createdUserDto.Degree, Is.EqualTo(userDto.Degree));
                Assert.That(createdUserDto.Specialization, Is.EqualTo(userDto.Specialization));
                Assert.That(createdUserDto.Hobbies, Is.EqualTo(userDto.Hobbies));
            });

            // Verify that the user was actually added to the database by retrieving it by ID
            var retrievedUser = _userRepository.GetUserById(createdUserDto.IdUser);
            Assert.IsNotNull(retrievedUser);
            Assert.That(retrievedUser.IdUser, Is.EqualTo(createdUserDto.IdUser));

            Console.WriteLine($"Le test CreateUser_WhenUserDtoIsProvided_CreatesUserInDatabase a réussi !");
            Console.WriteLine($"Utilisateur avec ID {createdUserDto.IdUser} a été créé.");
        }

        [Test]
        public void DeleteUser_ShouldDeleteUser_WhenUserIdExists()
        {
            // Act
            _userService.DeleteUser(1);

            // Assert
            var deletedUser = _dbContext.Users.Find(1);
            Assert.That(deletedUser, Is.Null);
        }
    }
}
