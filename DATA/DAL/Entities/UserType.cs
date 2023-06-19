using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class UserType
{
    [Key]
    public int IdUserType { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<User> UserCollection { get; set; } = new List<User>();
}
