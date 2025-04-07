using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class AddedExperienceInAppUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "AppUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Experience",
                table: "AppUser",
                column: "Experience")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUser_Experience",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "AppUser");
        }
    }
}
