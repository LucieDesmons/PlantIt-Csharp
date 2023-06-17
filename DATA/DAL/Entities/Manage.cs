namespace DATA.DAL.Entities;

public partial class Manage
{
    public int IdUserCustomer { get; set; }

    public int IdUserBotanist { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual User Botanist { get; set; } = null!;

    public virtual User Customer { get; set; } = null!;
}
