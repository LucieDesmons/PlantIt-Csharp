using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class AuthenticationMapper
    {
        public static AuthentificationDto MapToDto(Authentification authentification)
        {
            return new AuthentificationDto
            {
                IdAuthentification = authentification.IdAuthentification,
                Email = authentification.Email,
                Password = authentification.Password,
                User = authentification.User != null ? UserMapper.MapToDto(authentification.User) : null,
                PasswordHistoricCollection = authentification.PasswordHistoricCollection != null
                    ? authentification.PasswordHistoricCollection.Select(PasswordHistoricMapper.MapToDto).ToList()
                    : null
            };
        }

        public static Authentification MapToEntity(AuthentificationDto authentificationDto)
        {
            return new Authentification
            {
               // IdAuthentification = authentificationDto.IdAuthentification,
                Email = authentificationDto.Email,
                Password = authentificationDto.Password,
                PasswordHistoricCollection = authentificationDto.PasswordHistoricCollection != null
                    ? authentificationDto.PasswordHistoricCollection.Select(PasswordHistoricMapper.MapToEntity).ToList()
                    : null
            };
        }
    }
}
