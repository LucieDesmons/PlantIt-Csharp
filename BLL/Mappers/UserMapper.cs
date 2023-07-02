using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                IdUser = user.IdUser,
                Name = user.Name,
                FirstName = user.FirstName,
                Phone = user.Phone,
                Degree = user.Degree,
                Specialization = user.Specialization,
                Hobbies = user.Hobbies,
                Address = AddressMapper.MapToDto(user.Address),
                Authentication = AuthenticationMapper.MapToDto(user.Authentication),
                UserType = user.UserType != null ? UserTypeMapper.MapToDto(user.UserType) : null,
                BankDetailsCollection = user.BankDetailsCollection?.Select(BankDetailMapper.MapToDto).ToList(),
                ConversationUser1Collection = user.ConversationUser1Collection?.Select(ConversationMapper.MapToDto).ToList(),
                ConversationUser2Collection = user.ConversationUser2Collection?.Select(ConversationMapper.MapToDto).ToList(),
                CreatedByCollection = user.CreatedByCollection?.Select(CreatedByMapper.MapToDto).ToList(),
                MaintenanceCollection = user.MaintenanceCollection?.Select(MaintenanceMapper.MapToDto).ToList(),
                ManageBotanistCollection = user.ManageBotanistCollection?.Select(ManageMapper.MapToDto).ToList(),
                ManageCustomerCollection = user.ManageCustomerCollection?.Select(ManageMapper.MapToDto).ToList(),
                PlantCollection = user.PlantCollection?.Select(PlantMapper.MapToDto).ToList(),
                UserHistoricCollection = user.UserHistoricCollection?.Select(UserHistoricMapper.MapToDto).ToList()
            };
        }

        public static User MapToEntity(UserDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                FirstName = userDto.FirstName,
                Phone = userDto.Phone,
                Degree = userDto.Degree,
                Specialization = userDto.Specialization,
                Hobbies = userDto.Hobbies,
                Address = userDto.Address != null ? AddressMapper.MapToEntity(userDto.Address) : null,
                IdAddress = userDto.IdAddress,
                Authentication = userDto.Authentication != null ? AuthenticationMapper.MapToEntity(userDto.Authentication) : null,
                IdAuthentication = userDto.IdAuthentication,
                UserType = userDto.UserType != null ? UserTypeMapper.MapToEntity(userDto.UserType) : null,
                IdUserType = userDto.IdUserType,
                BankDetailsCollection = userDto.BankDetailsCollection?.Select(BankDetailMapper.MapToEntity).ToList(),
                ConversationUser1Collection = userDto.ConversationUser1Collection?.Select(ConversationMapper.MapToEntity).ToList(),
                ConversationUser2Collection = userDto.ConversationUser2Collection?.Select(ConversationMapper.MapToEntity).ToList(),
                CreatedByCollection = userDto.CreatedByCollection?.Select(CreatedByMapper.MapToEntity).ToList(),
                MaintenanceCollection = userDto.MaintenanceCollection?.Select(MaintenanceMapper.MapToEntity).ToList(),
                ManageBotanistCollection = userDto.ManageBotanistCollection?.Select(ManageMapper.MapToEntity).ToList(),
                ManageCustomerCollection = userDto.ManageCustomerCollection?.Select(ManageMapper.MapToEntity).ToList(),
                PlantCollection = userDto.PlantCollection?.Select(PlantMapper.MapToEntity).ToList(),
                UserHistoricCollection = userDto.UserHistoricCollection?.Select(UserHistoricMapper.MapToEntity).ToList()
            };
        }
    }
}
