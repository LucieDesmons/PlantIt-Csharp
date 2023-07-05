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
                IdAuthentication = passwordHistoric.IdAuthentication,
                Authentication = AuthenticationMapper.MapToDto(passwordHistoric.Authentication)
            };
        }

        public static PasswordHistoric MapToEntity(PasswordHistoricDto passwordHistoricDto)
        {
            return new PasswordHistoric
            {
                IdHistoric = passwordHistoricDto.IdHistoric,
                Password = passwordHistoricDto.Password,
                UpdateDate = passwordHistoricDto.UpdateDate,
                IdAuthentication = passwordHistoricDto.IdAuthentication,
                Authentication = AuthenticationMapper.MapToEntity(passwordHistoricDto.Authentication)
            };
        }
    }
}
