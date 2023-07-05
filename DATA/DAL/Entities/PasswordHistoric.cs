using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class PasswordHistoric
{
    [Key]
    public int IdHistoric { get; set; }

    public string? Password { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int IdAuthentication { get; set; }

    public virtual Authentication Authentication { get; set; } = null!;
}
