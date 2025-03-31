using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using SkillMatrixManagement.Constants;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateEmployeeSkillModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppEmployeeSkill_SkillDescription",
                table: "AppEmployeeSkill");

            migrationBuilder.DropColumn(
                name: "SkillDescription",
                table: "AppEmployeeSkill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Dictionary<string, ProficiencyEnum>>(
                name: "SkillDescription",
                table: "AppEmployeeSkill",
                type: "jsonb",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_SkillDescription",
                table: "AppEmployeeSkill",
                column: "SkillDescription")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }
    }
}
