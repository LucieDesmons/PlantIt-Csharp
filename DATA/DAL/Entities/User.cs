using System.ComponentModel.DataAnnotations;

namespace DATA.DAL.Entities;

public partial class User
{
    [Key]
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? FirstName { get; set; }

    public string? Phone { get; set; }

    public string? Degree { get; set; }

    public string? Specialization { get; set; }

    public string? Hobbies { get; set; }

    public int IdAddress { get; set; }

    public int IdUserType { get; set; }

    public int IdAuthentication { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Authentication Authentication { get; set; } = null!;

    public virtual UserType UserType { get; set; } = null!;

    public virtual ICollection<BankDetail> BankDetailsCollection { get; set; } = new List<BankDetail>();

    public virtual ICollection<Conversation> ConversationUser1Collection { get; set; } = new List<Conversation>();

    public virtual ICollection<Conversation> ConversationUser2Collection { get; set; } = new List<Conversation>();

    public virtual ICollection<CreatedBy> CreatedByCollection { get; set; } = new List<CreatedBy>();

    public virtual ICollection<Maintenance> MaintenanceCollection { get; set; } = new List<Maintenance>();

    public virtual ICollection<Manage> ManageBotanistCollection { get; set; } = new List<Manage>();

    public virtual ICollection<Manage> ManageCustomerCollection { get; set; } = new List<Manage>();

    public virtual ICollection<Plant> PlantCollection { get; set; } = new List<Plant>();

    public virtual ICollection<UserHistoric> UserHistoricCollection { get; set; } = new List<UserHistoric>();
}
