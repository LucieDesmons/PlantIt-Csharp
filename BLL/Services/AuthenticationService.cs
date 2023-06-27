using DATA.DTO;
using BLL.Interfaces;
using DATA.DAL.Repositories;
using BLL.Mappers;

namespace BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthentificationRepository _authenticationRepository;

        public AuthenticationService(IAuthentificationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public AuthentificationDto GetAuthentificationById(int idAuthentification)
        {
            try
            {
                var authentification = _authenticationRepository.GetAuthentificationById(idAuthentification);
                if (authentification == null)
                {
                    throw new Exception($"Authentification avec l'ID {idAuthentification} non trouvée.");
                }
                return AuthenticationMapper.MapToDto(authentification);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la récupération de l'authentification.", ex);
            }
        }

        public AuthentificationDto CreateAuthentification(AuthentificationDto authentificationDto)
        {
            try
            {
                var authentification = AuthenticationMapper.MapToEntity(authentificationDto);
                var createdAuthentification = _authenticationRepository.CreateAuthentification(authentification);
                return AuthenticationMapper.MapToDto(createdAuthentification);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la création de l'authentification.", ex);
            }
        }

        public AuthentificationDto UpdateAuthentification(AuthentificationDto authentificationDto)
        {
            try
            {
                var existingAuthentification = _authenticationRepository.GetAuthentificationById(authentificationDto.IdAuthentification);
                if (existingAuthentification == null)
                {
                    throw new Exception($"Authentification avec l'ID {authentificationDto.IdAuthentification} non trouvée.");
                }

                existingAuthentification.Email = authentificationDto.Email;

                // Hasher le mot de passe s'il a été modifié
                if (authentificationDto.Password != null)
                {
                    existingAuthentification.Password = HashPassword(authentificationDto.Password);
                }

                _authenticationRepository.UpdateAuthentification(existingAuthentification);

                return AuthenticationMapper.MapToDto(existingAuthentification);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la mise à jour de l'authentification.", ex);
            }
        }

        public void DeleteAuthentification(int idAuthentification)
        {
            try
            {
                var authentification = _authenticationRepository.GetAuthentificationById(idAuthentification);
                if (authentification == null)
                {
                    throw new Exception($"Authentification avec l'ID {idAuthentification} non trouvée.");
                }

                _authenticationRepository.DeleteAuthentification(authentification);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la suppression de l'authentification.", ex);
            }
        }


    }
}
