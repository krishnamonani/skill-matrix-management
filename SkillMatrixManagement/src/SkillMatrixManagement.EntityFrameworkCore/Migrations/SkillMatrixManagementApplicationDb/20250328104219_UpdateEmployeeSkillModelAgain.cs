using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateEmployeeSkillModelAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployeeSkill_AppUser_EndorserId",
                table: "AppEmployeeSkill");

            migrationBuilder.DropIndex(
                name: "IX_AppEmployeeSkill_EndorserId",
                table: "AppEmployeeSkill");

            migrationBuilder.DropColumn(
                name: "EndorserId",
                table: "AppEmployeeSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployeeSkill_AppUser_EndorsedBy",
                table: "AppEmployeeSkill",
                column: "EndorsedBy",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployeeSkill_AppUser_EndorsedBy",
                table: "AppEmployeeSkill");

            migrationBuilder.AddColumn<Guid>(
                name: "EndorserId",
                table: "AppEmployeeSkill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_EndorserId",
                table: "AppEmployeeSkill",
                column: "EndorserId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployeeSkill_AppUser_EndorserId",
                table: "AppEmployeeSkill",
                column: "EndorserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
