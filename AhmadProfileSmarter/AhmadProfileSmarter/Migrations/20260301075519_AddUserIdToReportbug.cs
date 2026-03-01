using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmadProfileSmarter.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToReportbug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reportbug",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reportbug_UserId",
                table: "Reportbug",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reportbug_Users_UserId",
                table: "Reportbug",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reportbug_Users_UserId",
                table: "Reportbug");

            migrationBuilder.DropIndex(
                name: "IX_Reportbug_UserId",
                table: "Reportbug");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reportbug");
        }
    }
}
