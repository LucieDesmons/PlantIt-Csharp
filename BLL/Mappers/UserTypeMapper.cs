using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class UserTypeMapper
    {
        public static UserTypeDto MapToDto(UserType userType)
        {
            return new UserTypeDto
            {
                IdUserType = userType.IdUserType,
                Label = userType.Label,
                UserCollection = userType.UserCollection?.Select(UserMapper.MapToDto).ToList()
            };
        }

        public static UserType MapToEntity(UserTypeDto userTypeDto)
        {
            return new UserType
            {
                Label = userTypeDto.Label,
                UserCollection = userTypeDto.UserCollection?.Select(UserMapper.MapToEntity).ToList()
            };
        }
    }
}
