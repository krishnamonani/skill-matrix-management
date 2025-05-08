using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class FixPercentageSpellingUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BillablePerncentage",
                table: "AppUser",
                newName: "BillablePercentage");

            migrationBuilder.RenameColumn(
                name: "AvailabilityPerncentage",
                table: "AppUser",
                newName: "AvailabilityPercentage");

            migrationBuilder.RenameColumn(
                name: "AssignibilityPerncentage",
                table: "AppUser",
                newName: "AssignibilityPercentage");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_BillablePerncentage",
                table: "AppUser",
                newName: "IX_AppUser_BillablePercentage");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_AvailabilityPerncentage",
                table: "AppUser",
                newName: "IX_AppUser_AvailabilityPercentage");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_AssignibilityPerncentage",
                table: "AppUser",
                newName: "IX_AppUser_AssignibilityPercentage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BillablePercentage",
                table: "AppUser",
                newName: "BillablePerncentage");

            migrationBuilder.RenameColumn(
                name: "AvailabilityPercentage",
                table: "AppUser",
                newName: "AvailabilityPerncentage");

            migrationBuilder.RenameColumn(
                name: "AssignibilityPercentage",
                table: "AppUser",
                newName: "AssignibilityPerncentage");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_BillablePercentage",
                table: "AppUser",
                newName: "IX_AppUser_BillablePerncentage");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_AvailabilityPercentage",
                table: "AppUser",
                newName: "IX_AppUser_AvailabilityPerncentage");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_AssignibilityPercentage",
                table: "AppUser",
                newName: "IX_AppUser_AssignibilityPerncentage");
        }
    }
}
