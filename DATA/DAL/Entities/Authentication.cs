using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class Authentication
{
    [Key]
    public int IdAuthentication { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<PasswordHistoric> PasswordHistoricCollection { get; set; } = new List<PasswordHistoric>();
}
