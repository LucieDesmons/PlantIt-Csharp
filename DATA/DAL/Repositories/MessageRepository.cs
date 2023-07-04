using DATA.DAL.Context;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IMessageRepository
    {
        Message GetMessageById(int id);
        List<Message> GetAllMessages();
        Message CreateMessage(Message message);
        Message UpdateMessage(Message message);
        void DeleteMessage(Message message);
        Message CreateMessageInConversation(Conversation conversation, int senderId, string contenu);
    }

    public class MessageRepository : IMessageRepository
    {
        private readonly PlantItContext _dbContext;

        public MessageRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Message GetMessageById(int id)
        {
            return _dbContext.Messages.Find(id);
        }

        public List<Message> GetAllMessages()
        {
            return _dbContext.Messages.ToList();
        }

        public Message CreateMessage(Message message)
        {
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
            return message;
        }

        public Message UpdateMessage(Message message)
        {
            _dbContext.Messages.Update(message);
            _dbContext.SaveChanges();
            return message;
        }

        public void DeleteMessage(Message message)
        {
            _dbContext.Messages.Remove(message);
            _dbContext.SaveChanges();
        }

        public Message CreateMessageInConversation(Conversation conversation, int senderId, string contenu)
        {
            Message message = new Message()
            {
                IdConversation = conversation.IdConversation,
                Label = contenu,
                UpdateDate = DateTime.Now,
                IdSender = senderId,
            };

            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();

            // met a jour la date du dernier message de la conversation
            conversation.LastMessage = DateTime.Now;
            _dbContext.Conversations.Update(conversation);
            _dbContext.SaveChanges();
            //_dbContext.Conversations.Where(c => c.IdConversation == conversation).First().LastMessage = DateTime.Now;

            return message;
        }
    }
}
