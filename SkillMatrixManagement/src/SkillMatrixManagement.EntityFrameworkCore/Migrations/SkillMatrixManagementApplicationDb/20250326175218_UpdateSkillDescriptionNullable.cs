using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using SkillMatrixManagement.Constants;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateSkillDescriptionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Dictionary<string, ProficiencyEnum>>(
                name: "SkillDescription",
                table: "AppEmployeeSkill",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(Dictionary<string, ProficiencyEnum>),
                oldType: "jsonb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Dictionary<string, ProficiencyEnum>>(
                name: "SkillDescription",
                table: "AppEmployeeSkill",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(Dictionary<string, ProficiencyEnum>),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
