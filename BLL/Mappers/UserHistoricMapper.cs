using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class UserHistoricMapper
    {
        public static UserHistoricDto MapToDto(UserHistoric userHistoric)
        {
            return new UserHistoricDto
            {
                IdUserHistoric = userHistoric.IdUserHistoric,
                IdUser = userHistoric.IdUser,
                Action = userHistoric.Action,
                Reason = userHistoric.Reason,
                Date = userHistoric.Date,
                User = UserMapper.MapToDto(userHistoric.User)
            };
        }

        public static UserHistoric MapToEntity(UserHistoricDto userHistoricDto)
        {
            return new UserHistoric
            {
                IdUserHistoric = userHistoricDto.IdUserHistoric,
                IdUser = userHistoricDto.IdUser,
                Action = userHistoricDto.Action,
                Reason = userHistoricDto.Reason,
                Date = userHistoricDto.Date,
                User = UserMapper.MapToEntity(userHistoricDto.User)
            };
        }
    }
}
