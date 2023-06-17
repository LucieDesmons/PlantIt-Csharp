namespace DATA.DAL.Entities;

public partial class Conversation
{
    public int IdConversation { get; set; }

    public int IdUser1 { get; set; }

    public int IdUser2 { get; set; }

    public virtual User User1 { get; set; } = null!;

    public virtual User User2 { get; set; } = null!;

    public virtual ICollection<Message> MessageCollection { get; set; } = new List<Message>();

    public virtual ICollection<Plant> PlantCollection { get; set; } = new List<Plant>();
}
