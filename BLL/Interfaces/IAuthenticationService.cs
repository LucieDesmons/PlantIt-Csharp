using DATA.DTO;

namespace BLL.Interfaces
{
    public interface IAuthenticationService
    {
        AuthentificationDto GetAuthentificationById(int idAuthentification);

        AuthentificationDto CreateAuthentification(AuthentificationDto authentificationDto);

        AuthentificationDto UpdateAuthentification(AuthentificationDto authentificationDto);

        void DeleteAuthentification(int idAuthentification);

        AuthentificationDto Authenticate(string email, string password);
    }
}
