using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class PlantReference
{
    [Key]
    public int IdPlantReference { get; set; }

    public string? Name { get; set; }

    public string? Family { get; set; }

    public string? Size { get; set; }

    public string? FoodSource { get; set; }

    public string? Reproduction { get; set; }

    public string? Lifetime { get; set; }

    public string? PlaceLife { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CreatedBy> CreatedByCollection { get; set; } = new List<CreatedBy>();

    public virtual ICollection<PictureReference> PictureReferenceCollection { get; set; } = new List<PictureReference>();

    public virtual ICollection<Plant> PlantCollection { get; set; } = new List<Plant>();
}
