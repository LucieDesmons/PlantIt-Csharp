using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class UserHistoric
{
    [Key]
    public int IdUserHistoric { get; set; }

    public int IdUser { get; set; }

    public string Action { get; set; } = null!;

    public string? Reason { get; set; }

    public DateTime Date { get; set; }

    public virtual User User { get; set; } = null!;
}
