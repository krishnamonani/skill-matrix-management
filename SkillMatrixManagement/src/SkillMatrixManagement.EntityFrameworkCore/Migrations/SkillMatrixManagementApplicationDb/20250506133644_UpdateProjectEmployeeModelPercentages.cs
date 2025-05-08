using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateProjectEmployeeModelPercentages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignibilityPercentage",
                table: "AppProjectEmployee",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillablePercentage",
                table: "AppProjectEmployee",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_AssignibilityPercentage",
                table: "AppProjectEmployee",
                column: "AssignibilityPercentage")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_BillablePercentage",
                table: "AppProjectEmployee",
                column: "BillablePercentage")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppProjectEmployee_AssignibilityPercentage",
                table: "AppProjectEmployee");

            migrationBuilder.DropIndex(
                name: "IX_AppProjectEmployee_BillablePercentage",
                table: "AppProjectEmployee");

            migrationBuilder.DropColumn(
                name: "AssignibilityPercentage",
                table: "AppProjectEmployee");

            migrationBuilder.DropColumn(
                name: "BillablePercentage",
                table: "AppProjectEmployee");
        }
    }
}
