namespace DATA.DAL.Entities;

public partial class PictureReference
{
    public int IdPictureReference { get; set; }

    public string? Path { get; set; }

    public DateTime? ModificationDate { get; set; }

    public virtual ICollection<PlantReference> PlantReferenceCollection { get; set; } = new List<PlantReference>();
}
