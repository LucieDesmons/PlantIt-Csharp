using BLL.Mappers;
using BLL.Services;
using DATA.DAL.DbContextt;
using DATA.DAL.Entities;
using DATA.DAL.Repositories;
using DATA.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTS.IntegrationTests
{
    public class UserServiceIntegrationTests
    {
        private PlantItContext _dbContext;
        private IUserRepository _userRepository;
        private UserService _userService;
        private IUserTypeRepository _userTypeRepository;
        private AddressRepository _addressRepository;
        private AddressService _addressService;
        private AuthentificationRepository _authentificationRepository;
        private AuthenticationService _authenticationService;

        [SetUp]
        public void Setup()
        {
            _dbContext = new PlantItContext();
            _addressRepository = new AddressRepository(_dbContext);
            _addressService = new AddressService(_addressRepository);
            _authentificationRepository = new AuthentificationRepository(_dbContext);
            _authenticationService = new AuthenticationService(_authentificationRepository);
            _userRepository = new UserRepository(_dbContext);
            _userService = new UserService(_userRepository, _addressService, _authenticationService);
            _userTypeRepository = new UserTypeRepository(_dbContext);
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

            var authentication = new Authentification
            {
                Email = "testCreateUser38@example.com",
                Password = "testPassword"
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
                Authentification = AuthenticationMapper.MapToDto(authentication),
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
    }
}
