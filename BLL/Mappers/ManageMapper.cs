using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class ManageMapper
    {
        public static ManageDto MapToDto(Manage manage)
        {
            return new ManageDto
            {
                IdUserCustomer = manage.IdUserCustomer,
                IdUserBotanist = manage.IdUserBotanist,
                StartDate = manage.StartDate,
                EndDate = manage.EndDate,
                Botanist = UserMapper.MapToDto(manage.Botanist),
                Customer = UserMapper.MapToDto(manage.Customer)
            };
        }

        public static Manage MapToEntity(ManageDto manageDto)
        {
            return new Manage
            {
                IdUserCustomer = manageDto.IdUserCustomer,
                IdUserBotanist = manageDto.IdUserBotanist,
                StartDate = manageDto.StartDate,
                EndDate = manageDto.EndDate,
                Botanist = UserMapper.MapToEntity(manageDto.Botanist),
                Customer = UserMapper.MapToEntity(manageDto.Customer)
            };
        }
    }
}
