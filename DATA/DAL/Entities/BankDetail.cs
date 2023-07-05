using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class BankDetail
{
    [Key]
    public int IdBankDetails { get; set; }

    public string? Details { get; set; }

    public int IdUser { get; set; }

    public virtual User User { get; set; } = null!;
}
