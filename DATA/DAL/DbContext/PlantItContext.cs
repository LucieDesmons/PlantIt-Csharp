using DATA.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DATA.DAL.DbContextt;

public partial class PlantItContext : DbContext
{
    public PlantItContext()
    {
    }

    public PlantItContext(DbContextOptions<PlantItContext> options)
        : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = true;
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Authentification> Authentifications { get; set; }

    public virtual DbSet<BankDetail> BankDetails { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<CreatedBy> CreatedBies { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Manage> Manages { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<PasswordHistoric> PasswordHistorics { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<PictureReference> PictureReferences { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<PlantReference> PlantReferences { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserHistoric> UserHistorics { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-2VS5454\\SQLEXPRESS;user id=sa; password=lucie;Initial Catalog=plant_it;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("PK_address_id_address");

            entity.ToTable("address");

            entity.HasIndex(e => e.IdAddress, "AK_address_idAddress_UNIQUE").IsUnique();

            entity.Property(e => e.IdAddress).HasColumnName("id_address");
            entity.Property(e => e.AdditionalAddress)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("additional_address");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("postal_code");
            entity.Property(e => e.Town)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("town");
            entity.Property(e => e.Way)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("way");
        });

        modelBuilder.Entity<Authentification>(entity =>
        {
            entity.HasKey(e => e.IdAuthentification).HasName("PK_authentification_id_authentification");

            entity.ToTable("authentification");

            entity.HasIndex(e => e.Email, "AK_authentification_login_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Password, "AK_authentification_password_UNIQUE").IsUnique();

            entity.Property(e => e.IdAuthentification)
                .ValueGeneratedNever()
                .HasColumnName("id_authentification");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<BankDetail>(entity =>
        {
            entity.HasKey(e => e.IdBankDetails).HasName("PK_bank_details_id_bank_betails");

            entity.ToTable("bank_details");

            entity.HasIndex(e => e.IdUser, "fk_bank_details_user1_idx");

            entity.Property(e => e.IdBankDetails)
                .ValueGeneratedNever()
                .HasColumnName("id_bank_betails");
            entity.Property(e => e.Details)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("details");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.User).WithMany(p => p.BankDetailsCollection)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bank_details_user");
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.IdConversation).HasName("PK_conversation_id_conversation");

            entity.ToTable("conversation");

            entity.HasIndex(e => e.IdConversation, "AK_conversation_idConversation_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdUser1, "fk_Conversation_User1_idx");

            entity.HasIndex(e => e.IdUser2, "fk_Conversation_User2_idx");

            entity.Property(e => e.IdConversation).HasColumnName("id_conversation");
            entity.Property(e => e.IdUser1).HasColumnName("id_user_1");
            entity.Property(e => e.IdUser2).HasColumnName("id_user_2");

            entity.HasOne(d => d.User1).WithMany(p => p.ConversationUser1Collection)
                .HasForeignKey(d => d.IdUser1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Conversation_User1");

            entity.HasOne(d => d.User2).WithMany(p => p.ConversationUser2Collection)
                .HasForeignKey(d => d.IdUser2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Conversation_User2");
        });

        modelBuilder.Entity<CreatedBy>(entity =>
        {
            entity.HasKey(e => new { e.IdPlantReference, e.IdUser }).HasName("PK_created_by_id_plant_reference_id_user");

            entity.ToTable("created_by");

            entity.HasIndex(e => e.IdPlantReference, "fk_PlantReference_has_User_PlantReference1_idx");

            entity.HasIndex(e => e.IdUser, "fk_PlantReference_has_User_User1_idx");

            entity.Property(e => e.IdPlantReference).HasColumnName("id_plant_reference");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.OrderNum).HasColumnName("order_num");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.PlantReference).WithMany(p => p.CreatedByCollection)
                .HasForeignKey(d => d.IdPlantReference)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_created_by_plant_reference");

            entity.HasOne(d => d.User).WithMany(p => p.CreatedByCollection)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_created_by_user");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.IdMaintenance).HasName("PK_maintenance_id_maintenance");

            entity.ToTable("maintenance");

            entity.HasIndex(e => e.IdMaintenance, "AK_maintenance_idMeeting_UNIQUE").IsUnique();

            entity.Property(e => e.IdMaintenance).HasColumnName("id_maintenance");
            entity.Property(e => e.PredictedDate)
                .HasColumnType("datetime")
                .HasColumnName("predicted_date");
            entity.Property(e => e.RealizedDate)
                .HasColumnType("datetime")
                .HasColumnName("realized_date");
            entity.Property(e => e.Report)
                .HasMaxLength(1500)
                .IsUnicode(false)
                .HasColumnName("report");

            entity.HasMany(d => d.PictureCollection).WithMany(p => p.MaintenanceCollection)
                .UsingEntity<Dictionary<string, object>>(
                    "MaintenancePicture",
                    r => r.HasOne<Picture>().WithMany()
                        .HasForeignKey("IdPicture")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Maintenance_has_Picture_Picture1"),
                    l => l.HasOne<Maintenance>().WithMany()
                        .HasForeignKey("IdMaintenance")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Maintenance_has_Picture_Maintenance1"),
                    j =>
                    {
                        j.HasKey("IdMaintenance", "IdPicture").HasName("PK_maintenance_picture_id_maintenance_id_picture");
                        j.ToTable("maintenance_picture");
                        j.HasIndex(new[] { "IdMaintenance" }, "fk_Maintenance_has_Picture_Maintenance1_idx");
                        j.HasIndex(new[] { "IdPicture" }, "fk_Maintenance_has_Picture_Picture1_idx");
                        j.IndexerProperty<int>("IdMaintenance").HasColumnName("id_maintenance");
                        j.IndexerProperty<int>("IdPicture").HasColumnName("id_picture");
                    });

            entity.HasMany(d => d.UserCollection).WithMany(p => p.MaintenanceCollection)
                .UsingEntity<Dictionary<string, object>>(
                    "MaintenanceUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Maintenance_has_User_User1"),
                    l => l.HasOne<Maintenance>().WithMany()
                        .HasForeignKey("IdMaintenance")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Maintenance_has_User_Maintenance1"),
                    j =>
                    {
                        j.HasKey("IdMaintenance", "IdUser").HasName("PK_maintenance_user_id_maintenance_id_user");
                        j.ToTable("maintenance_user");
                        j.HasIndex(new[] { "IdMaintenance" }, "fk_Maintenance_has_User_Maintenance1_idx");
                        j.HasIndex(new[] { "IdUser" }, "fk_Maintenance_has_User_User1_idx");
                        j.IndexerProperty<int>("IdMaintenance").HasColumnName("id_maintenance");
                        j.IndexerProperty<int>("IdUser").HasColumnName("id_user");
                    });
        });

        modelBuilder.Entity<Manage>(entity =>
        {
            entity.HasKey(e => new { e.IdUserCustomer, e.IdUserBotanist }).HasName("PK_manage_id_user_customer_id_user_botanist");

            entity.ToTable("manage");

            entity.HasIndex(e => e.IdUserCustomer, "fk_User_has_User_User1_idx");

            entity.HasIndex(e => e.IdUserBotanist, "fk_User_has_User_User2_idx");

            entity.Property(e => e.IdUserCustomer).HasColumnName("id_user_customer");
            entity.Property(e => e.IdUserBotanist).HasColumnName("id_user_botanist");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Botanist).WithMany(p => p.ManageBotanistCollection)
                .HasForeignKey(d => d.IdUserBotanist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_has_User_User2");

            entity.HasOne(d => d.Customer).WithMany(p => p.ManageCustomerCollection)
                .HasForeignKey(d => d.IdUserCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_has_User_User1");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.IdMessage).HasName("PK_message_id_message");

            entity.ToTable("message");

            entity.HasIndex(e => e.IdMessage, "AK_message_idMessage_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdConversation, "fk_Message_Conversation1_idx");

            entity.Property(e => e.IdMessage).HasColumnName("id_message");
            entity.Property(e => e.IdConversation).HasColumnName("id_conversation");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Conversation).WithMany(p => p.MessageCollection)
                .HasForeignKey(d => d.IdConversation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_Conversation1");
        });

        modelBuilder.Entity<PasswordHistoric>(entity =>
        {
            entity.HasKey(e => e.IdHistoric).HasName("PK_password_historic_id_historic");

            entity.ToTable("password_historic");

            entity.HasIndex(e => e.IdHistoric, "AK_password_historic_idHistoric_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdAuthentification, "fk_password_historic_authentification1_idx");

            entity.Property(e => e.IdHistoric).HasColumnName("id_historic");
            entity.Property(e => e.IdAuthentification).HasColumnName("authentification_id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Authentification).WithMany(p => p.PasswordHistoricCollection)
                .HasForeignKey(d => d.IdAuthentification)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_password_historic_authentification1");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.IdPicture).HasName("PK_picture_id_picture");

            entity.ToTable("picture");

            entity.HasIndex(e => e.IdPicture, "AK_picture_idPictures_UNIQUE").IsUnique();

            entity.Property(e => e.IdPicture).HasColumnName("id_picture");
            entity.Property(e => e.Path)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("path");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<PictureReference>(entity =>
        {
            entity.HasKey(e => e.IdPictureReference).HasName("PK_picture_reference_id_picture_reference");

            entity.ToTable("picture_reference");

            entity.HasIndex(e => e.IdPictureReference, "AK_picture_reference_idPictureReference_UNIQUE").IsUnique();

            entity.Property(e => e.IdPictureReference).HasColumnName("id_picture_reference");
            entity.Property(e => e.ModificationDate)
                .HasColumnType("datetime")
                .HasColumnName("modification_date");
            entity.Property(e => e.Path)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("path");
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.IdPlant).HasName("PK_plant_id_plant");

            entity.ToTable("plant");

            entity.HasIndex(e => e.IdPlant, "AK_plant_idPlant_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdPlantReference, "fk_Plant_PlantReference_idx");

            entity.HasIndex(e => e.IdUser, "fk_Plant_User1_idx");

            entity.Property(e => e.IdPlant).HasColumnName("id_plant");
            entity.Property(e => e.Clarity).HasColumnName("clarity");
            entity.Property(e => e.Container)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("container");
            entity.Property(e => e.Humidity).HasColumnName("humidity");
            entity.Property(e => e.IdPlantReference).HasColumnName("id_plant_reference");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PlacePlant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("place_plant");

            entity.HasOne(d => d.PlantReference).WithMany(p => p.PlantCollection)
                .HasForeignKey(d => d.IdPlantReference)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Plant_PlantReference1");

            entity.HasOne(d => d.User).WithMany(p => p.PlantCollection)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Plant_User1");

            entity.HasMany(d => d.ConversationCollection).WithMany(p => p.PlantCollection)
                .UsingEntity<Dictionary<string, object>>(
                    "PlantConversation",
                    r => r.HasOne<Conversation>().WithMany()
                        .HasForeignKey("IdConversation")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Plant_has_Conversation_Conversation1"),
                    l => l.HasOne<Plant>().WithMany()
                        .HasForeignKey("IdPlant")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Plant_has_Conversation_Plant1"),
                    j =>
                    {
                        j.HasKey("IdPlant", "IdConversation").HasName("PK_plant_conversation_id_plant_id_conversation");
                        j.ToTable("plant_conversation");
                        j.HasIndex(new[] { "IdConversation" }, "fk_Plant_has_Conversation_Conversation1_idx");
                        j.HasIndex(new[] { "IdPlant" }, "fk_Plant_has_Conversation_Plant1_idx");
                        j.IndexerProperty<int>("IdPlant").HasColumnName("id_plant");
                        j.IndexerProperty<int>("IdConversation").HasColumnName("id_conversation");
                    });

            entity.HasMany(d => d.PictureCollection).WithMany(p => p.PlantCollection)
                .UsingEntity<Dictionary<string, object>>(
                    "PlantPicture",
                    r => r.HasOne<Picture>().WithMany()
                        .HasForeignKey("IdPicture")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Plant_has_Picture_Picture1"),
                    l => l.HasOne<Plant>().WithMany()
                        .HasForeignKey("IdPlant")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Plant_has_Picture_Plant1"),
                    j =>
                    {
                        j.HasKey("IdPlant", "IdPicture").HasName("PK_plant_picture_id_plant_id_picture");
                        j.ToTable("plant_picture");
                        j.HasIndex(new[] { "IdPicture" }, "fk_Plant_has_Picture_Picture1_idx");
                        j.HasIndex(new[] { "IdPlant" }, "fk_Plant_has_Picture_Plant1_idx");
                        j.IndexerProperty<int>("IdPlant").HasColumnName("id_plant");
                        j.IndexerProperty<int>("IdPicture").HasColumnName("id_picture");
                    });
        });

        modelBuilder.Entity<PlantReference>(entity =>
        {
            entity.HasKey(e => e.IdPlantReference).HasName("PK_plant_reference_id_plant_reference");

            entity.ToTable("plant_reference");

            entity.HasIndex(e => e.IdPlantReference, "AK_plant_reference_idPlantReference_UNIQUE").IsUnique();

            entity.Property(e => e.IdPlantReference).HasColumnName("id_plant_reference");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Family)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("family");
            entity.Property(e => e.FoodSource)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("food_source");
            entity.Property(e => e.Lifetime)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lifetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PlaceLife)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("place_life");
            entity.Property(e => e.Reproduction)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("reproduction");
            entity.Property(e => e.Size)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("size");

            entity.HasMany(d => d.PictureReferenceCollection).WithMany(p => p.PlantReferenceCollection)
                .UsingEntity<Dictionary<string, object>>(
                    "ReferencedPicture",
                    r => r.HasOne<PictureReference>().WithMany()
                        .HasForeignKey("IdPictureReference")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PlantReference_has_PictureReference_PictureReference1"),
                    l => l.HasOne<PlantReference>().WithMany()
                        .HasForeignKey("IdPlantReference")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PlantReference_has_PictureReference_PlantReference1"),
                    j =>
                    {
                        j.HasKey("IdPlantReference", "IdPictureReference").HasName("PK_referenced_picture_id_plant_reference_id_picture_reference");
                        j.ToTable("referenced_picture");
                        j.HasIndex(new[] { "IdPictureReference" }, "fk_PlantReference_has_PictureReference_PictureReference1_idx");
                        j.HasIndex(new[] { "IdPlantReference" }, "fk_PlantReference_has_PictureReference_PlantReference1_idx");
                        j.IndexerProperty<int>("IdPlantReference").HasColumnName("id_plant_reference");
                        j.IndexerProperty<int>("IdPictureReference").HasColumnName("id_picture_reference");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK_user_id_user");

            entity.ToTable("user");

            entity.HasIndex(e => e.IdUser, "AK_user_idUser_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdAddress, "fk_User_Address1_idx");

            entity.HasIndex(e => e.IdUserType, "fk_User_UserType_idx");

            entity.HasIndex(e => e.IdAuthentification, "fk_user_authentification1_idx");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.IdAuthentification).HasColumnName("id_authentification");
            entity.Property(e => e.Degree)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("degree");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Hobbies)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hobbies");
            entity.Property(e => e.IdAddress).HasColumnName("id_address");
            entity.Property(e => e.IdUserType).HasColumnName("id_user_type");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Specialization)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("specialization");

            entity.HasOne(d => d.Address).WithOne(p => p.User)
                .HasForeignKey<Address>(d => d.IdAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Address1");

            entity.HasOne(d => d.Authentification).WithOne(p => p.User)
                .HasForeignKey<Authentification>(d => d.IdAuthentification)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Authentification1");

            entity.HasOne(d => d.UserType).WithMany(p => p.UserCollection)
                .HasForeignKey(d => d.IdUserType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_UserType");
        });

        modelBuilder.Entity<UserHistoric>(entity =>
        {
            entity.HasKey(e => new { e.IdUserHistoric, e.IdUser }).HasName("PK_user_historic_id_user_historic_id_user");

            entity.ToTable("user_historic");

            entity.HasIndex(e => e.IdUser, "fk_UserHistoric_User1_idx");

            entity.Property(e => e.IdUserHistoric)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_user_historic");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Action)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Reason)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("reason");

            entity.HasOne(d => d.User).WithMany(p => p.UserHistoricCollection)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserHistoric_User1");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.IdUserType).HasName("PK_user_type_id_user_type");

            entity.ToTable("user_type");

            entity.HasIndex(e => e.IdUserType, "AK_user_type_idUserType_UNIQUE").IsUnique();

            entity.Property(e => e.IdUserType).HasColumnName("id_user_type");
            entity.Property(e => e.Label)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
