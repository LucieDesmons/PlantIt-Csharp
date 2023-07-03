using DATA.DTO;
using BLL.Interfaces;
using DATA.DAL.Repositories;
using BLL.Mappers;

namespace BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public AuthenticationDto GetAuthenticationById(int idAuthentication)
        {
            try
            {
                var authentication = _authenticationRepository.GetAuthenticationById(idAuthentication);
                if (authentication == null)
                {
                    throw new Exception($"Authentication avec l'ID {idAuthentication} non trouvée.");
                }
                return AuthenticationMapper.MapToDto(authentication);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la récupération de l'Authentication.", ex);
            }
        }

        public AuthenticationDto CreateAuthentication(AuthenticationDto authenticationDto)
        {
            try
            {
                // Hasher le mot de passe avant de l'enregistrer
                //authenticationDto.Password = HashPassword(authenticationDto.Password);

                var createdAuthentication = _authenticationRepository.CreateAuthentication(AuthenticationMapper.MapToEntity(authenticationDto));
                Console.WriteLine($"ID après insertion: {createdAuthentication.IdAuthentication}");

                authenticationDto.IdAuthentication = createdAuthentication.IdAuthentication;

                return authenticationDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la création de l'Authentication.", ex);
            }
        }

        public AuthenticationDto UpdateAuthentication(AuthenticationDto authenticationDto)
        {
            try
            {
                var existingAuthentication = _authenticationRepository.GetAuthenticationById(authenticationDto.IdAuthentication);
                if (existingAuthentication == null)
                {
                    throw new Exception($"Authentication avec l'ID {authenticationDto.IdAuthentication} non trouvée.");
                }

                existingAuthentication.Email = authenticationDto.Email;

                // Hasher le mot de passe s'il a été modifié
                if (authenticationDto.Password != null)
                {
                    existingAuthentication.Password = HashPassword(authenticationDto.Password);
                }

                _authenticationRepository.UpdateAuthentication(existingAuthentication);

                return AuthenticationMapper.MapToDto(existingAuthentication);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la mise à jour de l'Authentication.", ex);
            }
        }

        public void DeleteAuthentication(int idAuthentication)
        {
            try
            {
                var Authentication = _authenticationRepository.GetAuthenticationById(idAuthentication);
                if (Authentication == null)
                {
                    throw new Exception($"Authentication avec l'ID {idAuthentication} non trouvée.");
                }

                _authenticationRepository.DeleteAuthentication(Authentication);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la suppression de l'Authentication.", ex);
            }
        }

        public AuthenticationDto Authenticate(string email, string password)
        {
            try
            {
                var authentication = _authenticationRepository.GetAuthenticationByEmail(email);
                if (authentication == null || !BCrypt.Net.BCrypt.Verify(password, authentication.Password))
                {
                    throw new Exception("Email ou mot de passe incorrect.");
                }

                return AuthenticationMapper.MapToDto(authentication);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de l'Authentication.", ex);
            }
        }
    }
}
