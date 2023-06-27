using DATA.DAL.Entities;
using DATA.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static UserDto MapToDto(User user)
        {
            UserDto dto = new UserDto();
            {
                dto.IdUser = user.IdUser;
                dto.Name = user.Name;
                dto.FirstName = user.FirstName;
                dto.Phone = user.Phone;
                dto.Degree = user.Degree;
                dto.Specialization = user.Specialization;
                dto.Hobbies = user.Hobbies;
                
                if (user.Address != null)
                    dto.Address = AddressMapper.MapToDto(user.Address);
                dto.IdAddress = user.IdAddress;

                if (user.Authentification != null)
                    dto.Authentification = AuthenticationMapper.MapToDto(user.Authentification);
                dto.IdAuthentification = user.IdAuthentification;

                if (user.UserType != null)
                    dto.UserType = UserTypeMapper.MapToDto(user.UserType);
                dto.IdUserType = user.IdUserType;

                dto.BankDetailsCollection = user.BankDetailsCollection?.Select(BankDetailMapper.MapToDto).ToList() ?? null;
                dto.ConversationUser1Collection = user.ConversationUser1Collection?.Select(ConversationMapper.MapToDto).ToList() ?? null;
                dto.ConversationUser2Collection = user.ConversationUser2Collection?.Select(ConversationMapper.MapToDto).ToList() ?? null;
                dto.CreatedByCollection = user.CreatedByCollection?.Select(CreatedByMapper.MapToDto).ToList() ?? null   ;
                dto.MaintenanceCollection = user.MaintenanceCollection?.Select(MaintenanceMapper.MapToDto).ToList() ?? null;
                dto.ManageBotanistCollection = user.ManageBotanistCollection?.Select(ManageMapper.MapToDto).ToList() ?? null;
                dto.ManageCustomerCollection = user.ManageCustomerCollection?.Select(ManageMapper.MapToDto).ToList() ?? null;
                dto.PlantCollection = user.PlantCollection?.Select(PlantMapper.MapToDto).ToList() ?? null;
                dto.UserHistoricCollection = user.UserHistoricCollection?.Select(UserHistoricMapper.MapToDto).ToList() ?? null;
            };
            return dto;
        }

        public static User MapToEntity(UserDto userDto)
        {
            var user = new User();

            {
                //type simple
                //user.IdUser = userDto.IdUser;
                
                user.Name = userDto.Name;
                user.FirstName = userDto.FirstName;
                user.Phone = userDto.Phone;
                user.Degree = userDto.Degree;
                user.Specialization = userDto.Specialization;
                user.Hobbies = userDto.Hobbies;
                

                // type complex
                //user.Address = AddressMapper.MapToEntity(userDto.Address);
                user.IdAddress = userDto.IdAddress;

                //user.Authentification = AuthenticationMapper.MapToEntity(userDto.Authentification);
                user.IdAuthentification = userDto.IdAuthentification;

                user.IdUserType = userDto.IdUserType;
                //user.UserType = userDto.UserType != null ? UserTypeMapper.MapToEntity(userDto.UserType) : null;


                // flemme
                user.BankDetailsCollection = userDto.BankDetailsCollection?.Select(BankDetailMapper.MapToEntity).ToList() ?? null;
                user.ConversationUser1Collection = userDto.ConversationUser1Collection?.Select(ConversationMapper.MapToEntity).ToList() ?? null;
                user.ConversationUser2Collection = userDto.ConversationUser2Collection?.Select(ConversationMapper.MapToEntity).ToList() ?? null;
                user.CreatedByCollection = userDto.CreatedByCollection?.Select(CreatedByMapper.MapToEntity).ToList() ?? null;
                user.MaintenanceCollection = userDto.MaintenanceCollection?.Select(MaintenanceMapper.MapToEntity).ToList() ?? null;
                user.ManageBotanistCollection = userDto.ManageBotanistCollection?.Select(ManageMapper.MapToEntity).ToList() ?? null;
                user.ManageCustomerCollection = userDto.ManageCustomerCollection?.Select(ManageMapper.MapToEntity).ToList() ?? null;
                user.PlantCollection = userDto.PlantCollection?.Select(PlantMapper.MapToEntity).ToList() ?? null;
                user.UserHistoricCollection = userDto.UserHistoricCollection?.Select(UserHistoricMapper.MapToEntity).ToList() ?? null;               
            };


            return user;
        }
    }
}
