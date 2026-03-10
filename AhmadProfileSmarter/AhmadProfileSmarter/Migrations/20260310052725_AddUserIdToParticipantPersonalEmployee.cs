using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmadProfileSmarter.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToParticipantPersonalEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "PersonalFiles",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "ParticipantFiles",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "EmployeeFiles",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalFiles_UserID",
                table: "PersonalFiles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFiles_UserID",
                table: "ParticipantFiles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFiles_UserID",
                table: "EmployeeFiles",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeFiles_Users_UserID",
                table: "EmployeeFiles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantFiles_Users_UserID",
                table: "ParticipantFiles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalFiles_Users_UserID",
                table: "PersonalFiles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeFiles_Users_UserID",
                table: "EmployeeFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantFiles_Users_UserID",
                table: "ParticipantFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalFiles_Users_UserID",
                table: "PersonalFiles");

            migrationBuilder.DropIndex(
                name: "IX_PersonalFiles_UserID",
                table: "PersonalFiles");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantFiles_UserID",
                table: "ParticipantFiles");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeFiles_UserID",
                table: "EmployeeFiles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "PersonalFiles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ParticipantFiles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "EmployeeFiles");
        }
    }
}
