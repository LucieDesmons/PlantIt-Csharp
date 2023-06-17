namespace DATA.DAL.Entities;

public partial class PasswordHistoric
{
    public int IdHistoric { get; set; }

    public string? Password { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int IdAuthentification { get; set; }

    public virtual Authentification Authentification { get; set; } = null!;
}
