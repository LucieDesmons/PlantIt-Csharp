using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class Message
{
    [Key]
    public int IdMessage { get; set; }

    public string? Label { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int IdConversation { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;
}
