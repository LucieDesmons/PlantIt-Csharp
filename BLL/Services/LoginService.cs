﻿using BLL.Interfaces;
using BLL.Mappers;
using DATA.DAL.Repositories;
using DATA.DTO;
using DATA.DTO.custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAuthentificationRepository _authentificationRepository;

        public LoginService(IAuthentificationRepository authentificationRepository)
        {
            _authentificationRepository = authentificationRepository;
        }

        public AuthentificationDto Authenticate(LoginModel loginModel)
        {
            try
            {
                var existingAuthentification = _authentificationRepository.GetAuthentificationByEmail(loginModel.Email);
                if (existingAuthentification == null || !BCrypt.Net.BCrypt.Verify(loginModel.Password, existingAuthentification.Password))
                {
                    throw new Exception("Email ou mot de passe incorrect.");
                }

                return AuthenticationMapper.MapToDto(existingAuthentification);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de l'authentification.", ex);
            }
        }
    }
}
