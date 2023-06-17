using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class AuthentificationMapper
    {
        public static AuthentificationDto MapToDto(Authentification authentification)
        {
            return new AuthentificationDto
            {
                IdAuthentification = authentification.IdAuthentification,
                Email = authentification.Email,
                Password = authentification.Password,
                User = UserMapper.MapToDto(authentification.User),
                PasswordHistoricCollection = authentification.PasswordHistoricCollection.Select(PasswordHistoricMapper.MapToDto).ToList()
            };
        }

        public static Authentification MapToEntity(AuthentificationDto authentificationDto)
        {
            return new Authentification
            {
                IdAuthentification = authentificationDto.IdAuthentification,
                Email = authentificationDto.Email,
                Password = authentificationDto.Password,
                User = UserMapper.MapToEntity(authentificationDto.User),
                PasswordHistoricCollection = authentificationDto.PasswordHistoricCollection.Select(PasswordHistoricMapper.MapToEntity).ToList()
            };
        }
    }
}
