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
                Authentification = AuthentificationMapper.MapToDto(user.Authentification),
                UserType = UserTypeMapper.MapToDto(user.UserType),
                BankDetailsCollection = user.BankDetailsCollection.Select(BankDetailMapper.MapToDto).ToList(),
                ConversationUser1Collection = user.ConversationUser1Collection.Select(ConversationMapper.MapToDto).ToList(),
                ConversationUser2Collection = user.ConversationUser2Collection.Select(ConversationMapper.MapToDto).ToList(),
                CreatedByCollection = user.CreatedByCollection.Select(CreatedByMapper.MapToDto).ToList(),
                MaintenanceCollection = user.MaintenanceCollection.Select(MaintenanceMapper.MapToDto).ToList(),
                ManageBotanistCollection = user.ManageBotanistCollection.Select(ManageMapper.MapToDto).ToList(),
                ManageCustomerCollection = user.ManageCustomerCollection.Select(ManageMapper.MapToDto).ToList(),
                PlantCollection = user.PlantCollection.Select(PlantMapper.MapToDto).ToList(),
                UserHistoricCollection = user.UserHistoricCollection.Select(UserHistoricMapper.MapToDto).ToList()
            };
        }

        public static User MapToEntity(UserDto userDto)
        {
            return new User
            {
                IdUser = userDto.IdUser,
                Name = userDto.Name,
                FirstName = userDto.FirstName,
                Phone = userDto.Phone,
                Degree = userDto.Degree,
                Specialization = userDto.Specialization,
                Hobbies = userDto.Hobbies,
                Address = AddressMapper.MapToEntity(userDto.Address),
                Authentification = AuthentificationMapper.MapToEntity(userDto.Authentification),
                UserType = UserTypeMapper.MapToEntity(userDto.UserType),
                BankDetailsCollection = userDto.BankDetailsCollection.Select(BankDetailMapper.MapToEntity).ToList(),
                ConversationUser1Collection = userDto.ConversationUser1Collection.Select(ConversationMapper.MapToEntity).ToList(),
                ConversationUser2Collection = userDto.ConversationUser2Collection.Select(ConversationMapper.MapToEntity).ToList(),
                CreatedByCollection = userDto.CreatedByCollection.Select(CreatedByMapper.MapToEntity).ToList(),
                MaintenanceCollection = userDto.MaintenanceCollection.Select(MaintenanceMapper.MapToEntity).ToList(),
                ManageBotanistCollection = userDto.ManageBotanistCollection.Select(ManageMapper.MapToEntity).ToList(),
                ManageCustomerCollection = userDto.ManageCustomerCollection.Select(ManageMapper.MapToEntity).ToList(),
                PlantCollection = userDto.PlantCollection.Select(PlantMapper.MapToEntity).ToList(),
                UserHistoricCollection = userDto.UserHistoricCollection.Select(UserHistoricMapper.MapToEntity).ToList()
            };
        }
    }
}
