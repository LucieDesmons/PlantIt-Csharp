using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class AuthenticationMapper
    {
        public static AuthenticationDto MapToDto(Authentication authentication)
        {
            return new AuthenticationDto
            {
                IdAuthentication = authentication.IdAuthentication,
                Email = authentication.Email,
                Password = authentication.Password,
                PasswordHistoricCollection = authentication.PasswordHistoricCollection != null
                    ? authentication.PasswordHistoricCollection.Select(PasswordHistoricMapper.MapToDto).ToList()
                    : null
            };
        }

        public static Authentication MapToEntity(AuthenticationDto authenticationDto)
        {
            return new Authentication
            {
               // IdAuthentication = authenticationDto.IdAuthentication,
                Email = authenticationDto.Email,
                Password = authenticationDto.Password,
                PasswordHistoricCollection = authenticationDto.PasswordHistoricCollection != null
                    ? authenticationDto.PasswordHistoricCollection.Select(PasswordHistoricMapper.MapToEntity).ToList()
                    : null
            };
        }
    }
}
