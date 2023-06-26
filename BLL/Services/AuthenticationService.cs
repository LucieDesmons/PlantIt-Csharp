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
                // Hasher le mot de passe avant de l'enregistrer
                authentificationDto.Password = HashPassword(authentificationDto.Password);

                var createdAuthentification = _authenticationRepository.CreateAuthentification(AuthenticationMapper.MapToEntity(authentificationDto));
                Console.WriteLine($"ID après insertion: {createdAuthentification.IdAuthentification}");

                authentificationDto.IdAuthentification = createdAuthentification.IdAuthentification;

                return authentificationDto;
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

        public AuthentificationDto Authenticate(string email, string password)
        {
            try
            {
                var authentification = _authenticationRepository.GetAuthentificationByEmail(email);
                if (authentification == null || !BCrypt.Net.BCrypt.Verify(password, authentification.Password))
                {
                    throw new Exception("Email ou mot de passe incorrect.");
                }

                return AuthenticationMapper.MapToDto(authentification);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de l'authentification.", ex);
            }
        }
    }
}
