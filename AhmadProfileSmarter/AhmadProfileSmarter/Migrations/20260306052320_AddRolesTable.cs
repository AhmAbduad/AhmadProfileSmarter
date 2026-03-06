using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmadProfileSmarter.Migrations
{
    public partial class AddRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1️⃣ Create Roles table first
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            // 2️⃣ Insert default role (so existing users have a valid FK)
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 1, "User" });

            // 3️⃣ Add RoleID column to Users table with default = 1
            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 1); // default to User

            // 4️⃣ Create index for RoleID
            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            // 5️⃣ Add Foreign Key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
