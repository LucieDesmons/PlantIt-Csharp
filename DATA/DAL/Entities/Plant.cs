using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class Plant
{
    [Key]
    public int IdPlant { get; set; }

    public string? Name { get; set; }

    public string? PlacePlant { get; set; }

    public string? Container { get; set; }

    public int? Humidity { get; set; }

    public int? Clarity { get; set; }

    public int IdUser { get; set; }

    public int IdPlantReference { get; set; }

    public virtual PlantReference PlantReference { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Conversation> ConversationCollection { get; set; } = new List<Conversation>();

    public virtual ICollection<Picture> PictureCollection { get; set; } = new List<Picture>();
}
