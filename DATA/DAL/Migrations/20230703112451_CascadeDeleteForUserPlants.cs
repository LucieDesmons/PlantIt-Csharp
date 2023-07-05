using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteForUserPlants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id_address = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: true),
                    postal_code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    way = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    additional_address = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    town = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_id_address", x => x.id_address);
                });

            migrationBuilder.CreateTable(
                name: "authentication",
                columns: table => new
                {
                    id_authentication = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    password = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authentication_id_authentication", x => x.id_authentication);
                });

            migrationBuilder.CreateTable(
                name: "maintenance",
                columns: table => new
                {
                    id_maintenance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    predicted_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    realized_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    report = table.Column<string>(type: "varchar(1500)", unicode: false, maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenance_id_maintenance", x => x.id_maintenance);
                });

            migrationBuilder.CreateTable(
                name: "picture",
                columns: table => new
                {
                    id_picture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    path = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_picture_id_picture", x => x.id_picture);
                });

            migrationBuilder.CreateTable(
                name: "picture_reference",
                columns: table => new
                {
                    id_picture_reference = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    path = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    modification_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_picture_reference_id_picture_reference", x => x.id_picture_reference);
                });

            migrationBuilder.CreateTable(
                name: "plant_reference",
                columns: table => new
                {
                    id_plant_reference = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    family = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    size = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    food_source = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    reproduction = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    lifetime = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    place_life = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plant_reference_id_plant_reference", x => x.id_plant_reference);
                });

            migrationBuilder.CreateTable(
                name: "user_type",
                columns: table => new
                {
                    id_user_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_type_id_user_type", x => x.id_user_type);
                });

            migrationBuilder.CreateTable(
                name: "password_historic",
                columns: table => new
                {
                    id_historic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_authentication = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password_historic_id_historic", x => x.id_historic);
                    table.ForeignKey(
                        name: "FK_password_historic_authentication1",
                        column: x => x.id_authentication,
                        principalTable: "authentication",
                        principalColumn: "id_authentication");
                });

            migrationBuilder.CreateTable(
                name: "maintenance_picture",
                columns: table => new
                {
                    id_maintenance = table.Column<int>(type: "int", nullable: false),
                    id_picture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenance_picture_id_maintenance_id_picture", x => new { x.id_maintenance, x.id_picture });
                    table.ForeignKey(
                        name: "FK_Maintenance_has_Picture_Maintenance1",
                        column: x => x.id_maintenance,
                        principalTable: "maintenance",
                        principalColumn: "id_maintenance");
                    table.ForeignKey(
                        name: "FK_Maintenance_has_Picture_Picture1",
                        column: x => x.id_picture,
                        principalTable: "picture",
                        principalColumn: "id_picture");
                });

            migrationBuilder.CreateTable(
                name: "referenced_picture",
                columns: table => new
                {
                    id_plant_reference = table.Column<int>(type: "int", nullable: false),
                    id_picture_reference = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_referenced_picture_id_plant_reference_id_picture_reference", x => new { x.id_plant_reference, x.id_picture_reference });
                    table.ForeignKey(
                        name: "FK_PlantReference_has_PictureReference_PictureReference1",
                        column: x => x.id_picture_reference,
                        principalTable: "picture_reference",
                        principalColumn: "id_picture_reference");
                    table.ForeignKey(
                        name: "FK_PlantReference_has_PictureReference_PlantReference1",
                        column: x => x.id_plant_reference,
                        principalTable: "plant_reference",
                        principalColumn: "id_plant_reference");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    first_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    degree = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    specialization = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    hobbies = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_address = table.Column<int>(type: "int", nullable: false),
                    id_user_type = table.Column<int>(type: "int", nullable: false),
                    id_authentication = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_id_user", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_User_Address1",
                        column: x => x.id_address,
                        principalTable: "address",
                        principalColumn: "id_address");
                    table.ForeignKey(
                        name: "FK_User_UserType",
                        column: x => x.id_user_type,
                        principalTable: "user_type",
                        principalColumn: "id_user_type");
                    table.ForeignKey(
                        name: "FK_user_authentication1",
                        column: x => x.id_authentication,
                        principalTable: "authentication",
                        principalColumn: "id_authentication");
                });

            migrationBuilder.CreateTable(
                name: "bank_details",
                columns: table => new
                {
                    id_bank_details = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bank_details = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_details_id_bank_betails", x => x.id_bank_details);
                    table.ForeignKey(
                        name: "FK_bank_details_user",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "conversation",
                columns: table => new
                {
                    id_conversation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user_1 = table.Column<int>(type: "int", nullable: false),
                    id_user_2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conversation_id_conversation", x => x.id_conversation);
                    table.ForeignKey(
                        name: "FK_Conversation_User1",
                        column: x => x.id_user_1,
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_Conversation_User2",
                        column: x => x.id_user_2,
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "created_by",
                columns: table => new
                {
                    id_plant_reference = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    order_num = table.Column<int>(type: "int", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_created_by_id_plant_reference_id_user", x => new { x.id_plant_reference, x.id_user });
                    table.ForeignKey(
                        name: "FK_created_by_plant_reference",
                        column: x => x.id_plant_reference,
                        principalTable: "plant_reference",
                        principalColumn: "id_plant_reference");
                    table.ForeignKey(
                        name: "FK_created_by_user",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "maintenance_user",
                columns: table => new
                {
                    id_maintenance = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenance_user_id_maintenance_id_user", x => new { x.id_maintenance, x.id_user });
                    table.ForeignKey(
                        name: "FK_Maintenance_has_User_Maintenance1",
                        column: x => x.id_maintenance,
                        principalTable: "maintenance",
                        principalColumn: "id_maintenance");
                    table.ForeignKey(
                        name: "FK_Maintenance_has_User_User1",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "manage",
                columns: table => new
                {
                    id_user_customer = table.Column<int>(type: "int", nullable: false),
                    id_user_botanist = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manage_id_user_customer_id_user_botanist", x => new { x.id_user_customer, x.id_user_botanist });
                    table.ForeignKey(
                        name: "FK_User_has_User_User1",
                        column: x => x.id_user_customer,
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_User_has_User_User2",
                        column: x => x.id_user_botanist,
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "plant",
                columns: table => new
                {
                    id_plant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    place_plant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    container = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    humidity = table.Column<int>(type: "int", nullable: true),
                    clarity = table.Column<int>(type: "int", nullable: true),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_plant_reference = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plant_id_plant", x => x.id_plant);
                    table.ForeignKey(
                        name: "FK_Plant_PlantReference1",
                        column: x => x.id_plant_reference,
                        principalTable: "plant_reference",
                        principalColumn: "id_plant_reference");
                    table.ForeignKey(
                        name: "FK_Plant_User1",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_historic",
                columns: table => new
                {
                    id_user_historic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    action = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    reason = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_historic_id_user_historic_id_user", x => new { x.id_user_historic, x.id_user });
                    table.ForeignKey(
                        name: "FK_UserHistoric_User1",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    id_message = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_conversation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_id_message", x => x.id_message);
                    table.ForeignKey(
                        name: "FK_Message_Conversation1",
                        column: x => x.id_conversation,
                        principalTable: "conversation",
                        principalColumn: "id_conversation");
                });

            migrationBuilder.CreateTable(
                name: "plant_conversation",
                columns: table => new
                {
                    id_plant = table.Column<int>(type: "int", nullable: false),
                    id_conversation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plant_conversation_id_plant_id_conversation", x => new { x.id_plant, x.id_conversation });
                    table.ForeignKey(
                        name: "FK_Plant_has_Conversation_Conversation1",
                        column: x => x.id_conversation,
                        principalTable: "conversation",
                        principalColumn: "id_conversation");
                    table.ForeignKey(
                        name: "FK_Plant_has_Conversation_Plant1",
                        column: x => x.id_plant,
                        principalTable: "plant",
                        principalColumn: "id_plant");
                });

            migrationBuilder.CreateTable(
                name: "plant_picture",
                columns: table => new
                {
                    id_plant = table.Column<int>(type: "int", nullable: false),
                    id_picture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plant_picture_id_plant_id_picture", x => new { x.id_plant, x.id_picture });
                    table.ForeignKey(
                        name: "FK_Plant_has_Picture_Picture1",
                        column: x => x.id_picture,
                        principalTable: "picture",
                        principalColumn: "id_picture");
                    table.ForeignKey(
                        name: "FK_Plant_has_Picture_Plant1",
                        column: x => x.id_plant,
                        principalTable: "plant",
                        principalColumn: "id_plant");
                });

            migrationBuilder.CreateIndex(
                name: "AK_address_idAddress_UNIQUE",
                table: "address",
                column: "id_address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_authentication_login_UNIQUE",
                table: "authentication",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "AK_authentication_password_UNIQUE",
                table: "authentication",
                column: "password",
                unique: true,
                filter: "[password] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "fk_bank_details_user1_idx",
                table: "bank_details",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "AK_conversation_idConversation_UNIQUE",
                table: "conversation",
                column: "id_conversation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Conversation_User1_idx",
                table: "conversation",
                column: "id_user_1");

            migrationBuilder.CreateIndex(
                name: "fk_Conversation_User2_idx",
                table: "conversation",
                column: "id_user_2");

            migrationBuilder.CreateIndex(
                name: "fk_PlantReference_has_User_PlantReference1_idx",
                table: "created_by",
                column: "id_plant_reference");

            migrationBuilder.CreateIndex(
                name: "fk_PlantReference_has_User_User1_idx",
                table: "created_by",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "AK_maintenance_idMeeting_UNIQUE",
                table: "maintenance",
                column: "id_maintenance",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Maintenance_has_Picture_Maintenance1_idx",
                table: "maintenance_picture",
                column: "id_maintenance");

            migrationBuilder.CreateIndex(
                name: "fk_Maintenance_has_Picture_Picture1_idx",
                table: "maintenance_picture",
                column: "id_picture");

            migrationBuilder.CreateIndex(
                name: "fk_Maintenance_has_User_Maintenance1_idx",
                table: "maintenance_user",
                column: "id_maintenance");

            migrationBuilder.CreateIndex(
                name: "fk_Maintenance_has_User_User1_idx",
                table: "maintenance_user",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "fk_User_has_User_User1_idx",
                table: "manage",
                column: "id_user_customer");

            migrationBuilder.CreateIndex(
                name: "fk_User_has_User_User2_idx",
                table: "manage",
                column: "id_user_botanist");

            migrationBuilder.CreateIndex(
                name: "AK_message_idMessage_UNIQUE",
                table: "message",
                column: "id_message",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Message_Conversation1_idx",
                table: "message",
                column: "id_conversation");

            migrationBuilder.CreateIndex(
                name: "AK_password_historic_idHistoric_UNIQUE",
                table: "password_historic",
                column: "id_historic",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_password_historic_authentication1_idx",
                table: "password_historic",
                column: "id_authentication");

            migrationBuilder.CreateIndex(
                name: "AK_picture_idPictures_UNIQUE",
                table: "picture",
                column: "id_picture",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_picture_reference_idPictureReference_UNIQUE",
                table: "picture_reference",
                column: "id_picture_reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_plant_idPlant_UNIQUE",
                table: "plant",
                column: "id_plant",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Plant_PlantReference_idx",
                table: "plant",
                column: "id_plant_reference");

            migrationBuilder.CreateIndex(
                name: "fk_Plant_User1_idx",
                table: "plant",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "fk_Plant_has_Conversation_Conversation1_idx",
                table: "plant_conversation",
                column: "id_conversation");

            migrationBuilder.CreateIndex(
                name: "fk_Plant_has_Conversation_Plant1_idx",
                table: "plant_conversation",
                column: "id_plant");

            migrationBuilder.CreateIndex(
                name: "fk_Plant_has_Picture_Picture1_idx",
                table: "plant_picture",
                column: "id_picture");

            migrationBuilder.CreateIndex(
                name: "fk_Plant_has_Picture_Plant1_idx",
                table: "plant_picture",
                column: "id_plant");

            migrationBuilder.CreateIndex(
                name: "AK_plant_reference_idPlantReference_UNIQUE",
                table: "plant_reference",
                column: "id_plant_reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_PlantReference_has_PictureReference_PictureReference1_idx",
                table: "referenced_picture",
                column: "id_picture_reference");

            migrationBuilder.CreateIndex(
                name: "fk_PlantReference_has_PictureReference_PlantReference1_idx",
                table: "referenced_picture",
                column: "id_plant_reference");

            migrationBuilder.CreateIndex(
                name: "AK_user_idUser_UNIQUE",
                table: "user",
                column: "id_user",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_User_Address1_idx",
                table: "user",
                column: "id_address");

            migrationBuilder.CreateIndex(
                name: "fk_user_authentication1_idx",
                table: "user",
                column: "id_authentication");

            migrationBuilder.CreateIndex(
                name: "fk_User_UserType_idx",
                table: "user",
                column: "id_user_type");

            migrationBuilder.CreateIndex(
                name: "fk_UserHistoric_User1_idx",
                table: "user_historic",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "AK_user_type_idUserType_UNIQUE",
                table: "user_type",
                column: "id_user_type",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bank_details");

            migrationBuilder.DropTable(
                name: "created_by");

            migrationBuilder.DropTable(
                name: "maintenance_picture");

            migrationBuilder.DropTable(
                name: "maintenance_user");

            migrationBuilder.DropTable(
                name: "manage");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "password_historic");

            migrationBuilder.DropTable(
                name: "plant_conversation");

            migrationBuilder.DropTable(
                name: "plant_picture");

            migrationBuilder.DropTable(
                name: "referenced_picture");

            migrationBuilder.DropTable(
                name: "user_historic");

            migrationBuilder.DropTable(
                name: "maintenance");

            migrationBuilder.DropTable(
                name: "conversation");

            migrationBuilder.DropTable(
                name: "picture");

            migrationBuilder.DropTable(
                name: "plant");

            migrationBuilder.DropTable(
                name: "picture_reference");

            migrationBuilder.DropTable(
                name: "plant_reference");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "user_type");

            migrationBuilder.DropTable(
                name: "authentication");
        }
    }
}
