using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class PasswordHistoricMapper
    {
        public static PasswordHistoricDto MapToDto(PasswordHistoric passwordHistoric)
        {
            return new PasswordHistoricDto
            {
                IdHistoric = passwordHistoric.IdHistoric,
                Password = passwordHistoric.Password,
                UpdateDate = passwordHistoric.UpdateDate,
                IdAuthentification = passwordHistoric.IdAuthentification,
                Authentification = AuthentificationMapper.MapToDto(passwordHistoric.Authentification)
            };
        }

        public static PasswordHistoric MapToEntity(PasswordHistoricDto passwordHistoricDto)
        {
            return new PasswordHistoric
            {
                IdHistoric = passwordHistoricDto.IdHistoric,
                Password = passwordHistoricDto.Password,
                UpdateDate = passwordHistoricDto.UpdateDate,
                IdAuthentification = passwordHistoricDto.IdAuthentification,
                Authentification = AuthentificationMapper.MapToEntity(passwordHistoricDto.Authentification)
            };
        }
    }
}
