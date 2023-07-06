using BLL.Interfaces;
using BLL.Mappers;
using DATA.DAL.Context;
using DATA.DAL.Entities;
using DATA.DAL.Repositories;
using DATA.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMessageRepository _messageRepository;

        public ChatService(IConversationRepository conversationRepository, IMessageRepository messageRepository)
        {
            _conversationRepository = conversationRepository;
            _messageRepository = messageRepository;
        }

        public ConversationDto LoadConversation(int conversationId)
        {
            try
            {
                Conversation conv = _conversationRepository.GetConversationById(conversationId);
                return ConversationMapper.MapToDto(conv);
            }
            catch (Exception ex)
            {

                throw new Exception("Une erreur est suvenue lors du chargement de la conversation", ex);
            }
        }

        public List<ConversationDto> GetConversationsOfUser(int userId)
        {
            try
            {
                var conversationsOfUser = _conversationRepository.GetConversationsOFUser(userId);
                return conversationsOfUser.Select(c => ConversationMapper.MapToDto(c)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur est survenue lors de la récupération des conversation de l'utilisateurs", ex);
            }
        }

        public ConversationDto CreateConversation(int senderId, int receiverId)
        {
            try
            {
                if (_conversationRepository.ConversationExist(senderId, receiverId))
                {
                    throw new Exception("La conversation entre les 2 utilisateurs existe déjà");
                }

                Conversation newConv = _conversationRepository.CreateConversation(senderId, receiverId);

                return ConversationMapper.MapToDto(newConv);
            }
            catch (Exception ex)
            {

                throw new Exception("Une erreur est survenue lors de la création d'une conversation", ex);
            }
        }

        public MessageDto SendMessage(int conversationId, int senderId, string contenu)
        {
            try
            {
                Conversation currentConversation = _conversationRepository.GetConversationById(conversationId);

                Message message = _messageRepository.CreateMessageInConversation(currentConversation, senderId, contenu);

                return MessageMapper.MapToDto(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
