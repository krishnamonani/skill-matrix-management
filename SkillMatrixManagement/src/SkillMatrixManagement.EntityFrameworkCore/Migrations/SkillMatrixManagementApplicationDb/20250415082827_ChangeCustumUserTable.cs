using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class ChangeCustumUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "CustomUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "CustomUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "CustomUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "CustomUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "CustomUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "CustomUsers",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "CustomUsers");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CustomUsers");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "CustomUsers");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "CustomUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomUsers");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "CustomUsers");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "CustomUsers");
        }
    }
}
