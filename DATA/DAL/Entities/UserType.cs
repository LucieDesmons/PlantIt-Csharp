namespace DATA.DAL.Entities;

public partial class UserType
{
    public int IdUserType { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<User> UserCollection { get; set; } = new List<User>();
}
