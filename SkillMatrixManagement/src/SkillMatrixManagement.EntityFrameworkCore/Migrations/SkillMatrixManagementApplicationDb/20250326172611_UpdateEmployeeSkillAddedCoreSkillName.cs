using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateEmployeeSkillAddedCoreSkillName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployeeSkill_AppSkill_SkillId",
                table: "AppEmployeeSkill");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillId",
                table: "AppEmployeeSkill",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "CoreSkillName",
                table: "AppEmployeeSkill",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_CoreSkillName",
                table: "AppEmployeeSkill",
                column: "CoreSkillName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployeeSkill_AppSkill_SkillId",
                table: "AppEmployeeSkill",
                column: "SkillId",
                principalTable: "AppSkill",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployeeSkill_AppSkill_SkillId",
                table: "AppEmployeeSkill");

            migrationBuilder.DropIndex(
                name: "IX_AppEmployeeSkill_CoreSkillName",
                table: "AppEmployeeSkill");

            migrationBuilder.DropColumn(
                name: "CoreSkillName",
                table: "AppEmployeeSkill");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillId",
                table: "AppEmployeeSkill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployeeSkill_AppSkill_SkillId",
                table: "AppEmployeeSkill",
                column: "SkillId",
                principalTable: "AppSkill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
