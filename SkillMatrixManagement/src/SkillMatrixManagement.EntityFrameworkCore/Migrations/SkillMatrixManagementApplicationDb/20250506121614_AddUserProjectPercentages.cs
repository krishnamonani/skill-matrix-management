using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class AddUserProjectPercentages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignibilityPerncentage",
                table: "AppUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvailabilityPerncentage",
                table: "AppUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillablePerncentage",
                table: "AppUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectEndDate",
                table: "AppProjectEmployee",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectStartDate",
                table: "AppProjectEmployee",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_AssignibilityPerncentage",
                table: "AppUser",
                column: "AssignibilityPerncentage")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_AvailabilityPerncentage",
                table: "AppUser",
                column: "AvailabilityPerncentage")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_BillablePerncentage",
                table: "AppUser",
                column: "BillablePerncentage")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_ProjectEndDate",
                table: "AppProjectEmployee",
                column: "ProjectEndDate")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_ProjectStartDate",
                table: "AppProjectEmployee",
                column: "ProjectStartDate")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUser_AssignibilityPerncentage",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_AvailabilityPerncentage",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_BillablePerncentage",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppProjectEmployee_ProjectEndDate",
                table: "AppProjectEmployee");

            migrationBuilder.DropIndex(
                name: "IX_AppProjectEmployee_ProjectStartDate",
                table: "AppProjectEmployee");

            migrationBuilder.DropColumn(
                name: "AssignibilityPerncentage",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "AvailabilityPerncentage",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "BillablePerncentage",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "ProjectEndDate",
                table: "AppProjectEmployee");

            migrationBuilder.DropColumn(
                name: "ProjectStartDate",
                table: "AppProjectEmployee");
        }
    }
}
