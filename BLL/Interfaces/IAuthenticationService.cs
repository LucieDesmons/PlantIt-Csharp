using DATA.DTO;

namespace BLL.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationDto GetAuthenticationById(int idAuthentication);

        AuthenticationDto CreateAuthentication(AuthenticationDto authenticationDto);

        AuthenticationDto UpdateAuthentication(AuthenticationDto authenticationDto);

        void DeleteAuthentication(int idAuthentication);

        AuthenticationDto Authenticate(string email, string password);
    }
}
