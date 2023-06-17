using DATA.DAL.DbContextt;
using DATA.DAL.Entities;

namespace DATA.DAL.Repositories
{
    public interface IConversationRepository
    {
        Conversation GetConversationById(int id);
        List<Conversation> GetAllConversations();
        Conversation CreateConversation(Conversation conversation);
        Conversation UpdateConversation(Conversation conversation);
        void DeleteConversation(Conversation conversation);
    }

    public class ConversationRepository : IConversationRepository
    {
        private readonly PlantItContext _dbContext;

        public ConversationRepository(PlantItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Conversation GetConversationById(int id)
        {
            return _dbContext.Conversations.Find(id);
        }

        public List<Conversation> GetAllConversations()
        {
            return _dbContext.Conversations.ToList();
        }

        public Conversation CreateConversation(Conversation conversation)
        {
            _dbContext.Conversations.Add(conversation);
            _dbContext.SaveChanges();
            return conversation;
        }

        public Conversation UpdateConversation(Conversation conversation)
        {
            _dbContext.Conversations.Update(conversation);
            _dbContext.SaveChanges();
            return conversation;
        }

        public void DeleteConversation(Conversation conversation)
        {
            _dbContext.Conversations.Remove(conversation);
            _dbContext.SaveChanges();
        }
    }
}
