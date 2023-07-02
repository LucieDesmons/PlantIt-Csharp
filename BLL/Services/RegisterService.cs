using BLL.Interfaces;
using BLL.Mappers;
using DATA.DAL.Context;
using DATA.DAL.Entities;
using DATA.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly PlantItContext _context;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public RegisterService(PlantItContext context,
                               IAuthenticationService authenticationService,
                               IAddressService addressService,
                               IUserService userService)
        {
            _context = context;
            _authenticationService = authenticationService;
            _addressService = addressService;
            _userService = userService;
        }

        public async Task<AuthenticationDto> RegisterUser(RegisterModel model)
        {
            try
            {
                var user = new AuthenticationDto
                {
                    Email = model.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
                };
                user = _authenticationService.CreateAuthentication(user);


                var address = new AddressDto()
                {
                    Number = model.AddressNumber,
                    PostalCode = model.PostalCode,
                    Way = model.AddressWay,
                    AdditionalAddress = model.AdditionalAddress,
                    Town = model.AddressTown
                };
                address = _addressService.CreateAddress(address);

                var userDetails = new UserDto
                {
                    Name = model.LastName,
                    FirstName = model.FirstName,
                    Phone = model.Phone,
                    Degree = model.Degree,
                    Specialization = model.Specialization,
                    
                    IdUserType = model.IdUserType, //pas utile de stocker tout le type d'utilisateur vu l'id suffit.
                  
                    //Authentication = user,
                    IdAuthentication = user.IdAuthentication,
                    //Address = address,
                    IdAddress = address.IdAddress,
                    IdUser = user.IdAuthentication,
                };
                userDetails = _userService.CreateUser(userDetails);

                return user;

            }
            catch (Exception e)
            {
                throw;
            }



        }
    }
}
