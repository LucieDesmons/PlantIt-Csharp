using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class CreatedBy
{
    [Key]
    public int IdPlantReference { get; set; }

    public int IdUser { get; set; }

    public int? OrderNum { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual PlantReference PlantReference { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
