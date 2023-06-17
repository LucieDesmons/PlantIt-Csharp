using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class ConversationMapper
    {
        public static ConversationDto MapToDto(Conversation conversation)
        {
            return new ConversationDto
            {
                IdConversation = conversation.IdConversation,
                IdUser1 = conversation.IdUser1,
                IdUser2 = conversation.IdUser2,
                User1 = UserMapper.MapToDto(conversation.User1),
                User2 = UserMapper.MapToDto(conversation.User2),
                MessageCollection = conversation.MessageCollection.Select(MessageMapper.MapToDto).ToList(),
                PlantCollection = conversation.PlantCollection.Select(PlantMapper.MapToDto).ToList()
            };
        }

        public static Conversation MapToEntity(ConversationDto conversationDto)
        {
            return new Conversation
            {
                IdConversation = conversationDto.IdConversation,
                IdUser1 = conversationDto.IdUser1,
                IdUser2 = conversationDto.IdUser2,
                User1 = UserMapper.MapToEntity(conversationDto.User1),
                User2 = UserMapper.MapToEntity(conversationDto.User2),
                MessageCollection = conversationDto.MessageCollection.Select(MessageMapper.MapToEntity).ToList(),
                PlantCollection = conversationDto.PlantCollection.Select(PlantMapper.MapToEntity).ToList()
            };
        }
    }

}
