using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class ModifiedSkillHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSkillHistory_AppSkill_SkillId",
                table: "AppSkillHistory");

            migrationBuilder.DropIndex(
                name: "IX_AppSkillHistory_SkillId",
                table: "AppSkillHistory");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "AppSkillHistory");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "AppSkillHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "CoreSkillName",
                table: "AppSkillHistory",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_CoreSkillName",
                table: "AppSkillHistory",
                column: "CoreSkillName")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppSkillHistory_CoreSkillName",
                table: "AppSkillHistory");

            migrationBuilder.DropColumn(
                name: "CoreSkillName",
                table: "AppSkillHistory");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "AppSkillHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SkillId",
                table: "AppSkillHistory",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_SkillId",
                table: "AppSkillHistory",
                column: "SkillId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSkillHistory_AppSkill_SkillId",
                table: "AppSkillHistory",
                column: "SkillId",
                principalTable: "AppSkill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
