using DATA.DAL.Context;
using DATA.DAL.Entities;
using DATA.DTO;

namespace DATA.DAL.Repositories
{
    public interface IConversationRepository
    {
        Conversation GetConversationById(int id);
        List<Conversation> GetAllConversations();
        Conversation CreateConversation(Conversation conversation);
        Conversation UpdateConversation(Conversation conversation);
        void DeleteConversation(Conversation conversation);
        IEnumerable<Conversation> GetConversationsOFUser(int userId);
        Conversation CreateConversation(int senderId, int receiverId);
        bool ConversationExist(int senderId, int receiverId);
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

        public IEnumerable<Conversation> GetConversationsOFUser(int userId)
        {
            return _dbContext.Conversations.Where(c => c.IdUser2 == userId || c.IdUser1 == userId);
        }

        public Conversation CreateConversation(int senderId, int receiverId)
        {
            try
            {
                Conversation newConv = new Conversation()
                {
                    IdUser1 = senderId,
                    IdUser2 = receiverId,
                };

                return CreateConversation(newConv);
            }
            catch (Exception ex)
            {

                throw new Exception("Une erreur est survenue lors de la création d'une conversation", ex);
            }
        }

        public bool ConversationExist(int senderId, int receiverId)
        {
            return _dbContext.Conversations.Any(c => c.IdUser1 == senderId && c.IdUser2 == receiverId);
        }
    }
}
