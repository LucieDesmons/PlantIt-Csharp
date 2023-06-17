using DATA.DAL.DbContextt;
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
    }
}
