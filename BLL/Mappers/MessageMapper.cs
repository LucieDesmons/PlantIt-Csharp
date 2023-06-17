using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class MessageMapper
    {
        public static MessageDto MapToDto(Message message)
        {
            return new MessageDto
            {
                IdMessage = message.IdMessage,
                Label = message.Label,
                UpdateDate = message.UpdateDate,
                IdConversation = message.IdConversation,
                Conversation = ConversationMapper.MapToDto(message.Conversation)
            };
        }

        public static Message MapToEntity(MessageDto messageDto)
        {
            return new Message
            {
                IdMessage = messageDto.IdMessage,
                Label = messageDto.Label,
                UpdateDate = messageDto.UpdateDate,
                IdConversation = messageDto.IdConversation,
                Conversation = ConversationMapper.MapToEntity(messageDto.Conversation)
            };
        }
    }
}
