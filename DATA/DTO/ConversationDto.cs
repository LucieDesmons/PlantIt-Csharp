namespace DATA.DTO
{
    public class ConversationDto
    {
        public int IdConversation { get; set; }

        public int IdUser1 { get; set; }

        public int IdUser2 { get; set; }

        public UserDto User1 { get; set; }

        public UserDto User2 { get; set; }

        public List<MessageDto> MessageCollection { get; set; }

        public List<PlantDto> PlantCollection { get; set; }
 
        public DateTime? LastMessage { get; set; }
    }
}
