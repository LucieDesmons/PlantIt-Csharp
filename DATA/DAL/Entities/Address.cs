using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class Address
{
    [Key]
    public int IdAddress { get; set; }

    public int? Number { get; set; }

    public string? PostalCode { get; set; }

    public string? Way { get; set; }

    public string? AdditionalAddress { get; set; }

    public string? Town { get; set; }

    public virtual User? User { get; set; }
}
