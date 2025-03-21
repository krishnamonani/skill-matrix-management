using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateDescriptionAsJsonbSkillSubtopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<Dictionary<string, string>>(
            //    name: "Description",
            //    table: "AppSkillSubtopic",
            //    type: "jsonb",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text");

            migrationBuilder.Sql("ALTER TABLE \"AppSkillSubtopic\" ALTER COLUMN \"Description\" TYPE jsonb USING \"Description\"::jsonb;");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppSkillSubtopic",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Dictionary<string, string>),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
