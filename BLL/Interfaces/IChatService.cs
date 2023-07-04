using BLL.Mappers;
using DATA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IChatService
    {
        List<ConversationDto> GetConversationsOfUser(int userId);
        ConversationDto CreateConversation(int senderId, int receiverId);
        MessageDto SendMessage(int conversationId, int senderId, string contenu);
        ConversationDto LoadConversation(int conversationId);
    }
}
