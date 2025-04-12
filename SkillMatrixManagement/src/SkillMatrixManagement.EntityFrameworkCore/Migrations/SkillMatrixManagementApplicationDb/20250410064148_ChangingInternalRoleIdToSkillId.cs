using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class ChangingInternalRoleIdToSkillId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_AppDepartmentInternalRole_InternalRoleId",
                table: "AppUser");

            migrationBuilder.RenameColumn(
                name: "InternalRoleId",
                table: "AppUser",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_InternalRoleId",
                table: "AppUser",
                newName: "IX_AppUser_SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_AppSkill_SkillId",
                table: "AppUser",
                column: "SkillId",
                principalTable: "AppSkill",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_AppSkill_SkillId",
                table: "AppUser");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "AppUser",
                newName: "InternalRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_SkillId",
                table: "AppUser",
                newName: "IX_AppUser_InternalRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_AppDepartmentInternalRole_InternalRoleId",
                table: "AppUser",
                column: "InternalRoleId",
                principalTable: "AppDepartmentInternalRole",
                principalColumn: "Id");
        }
    }
}
