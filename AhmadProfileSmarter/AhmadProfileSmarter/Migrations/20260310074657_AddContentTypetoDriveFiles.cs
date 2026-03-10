using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmadProfileSmarter.Migrations
{
    /// <inheritdoc />
    public partial class AddContentTypetoDriveFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PersonalFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "ParticipantFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "EmployeeFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PersonalFiles");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "ParticipantFiles");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "EmployeeFiles");
        }
    }
}
