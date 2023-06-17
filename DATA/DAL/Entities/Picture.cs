namespace DATA.DAL.Entities;

public partial class Picture
{
    public int IdPicture { get; set; }

    public string? Path { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Maintenance> MaintenanceCollection { get; set; } = new List<Maintenance>();

    public virtual ICollection<Plant> PlantCollection { get; set; } = new List<Plant>();
}
