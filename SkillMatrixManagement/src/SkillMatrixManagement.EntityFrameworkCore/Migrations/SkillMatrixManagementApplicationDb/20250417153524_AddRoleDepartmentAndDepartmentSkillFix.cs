using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class AddRoleDepartmentAndDepartmentSkillFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDepartmentSkill_AppDepartment_DeleterId",
                table: "AppDepartmentSkill");

            migrationBuilder.DropIndex(
                name: "IX_AppRoleDepartment_RoleId_DepartmentId",
                table: "AppRoleDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AppDepartmentSkill_DeleterId_SkillId",
                table: "AppDepartmentSkill");

            migrationBuilder.CreateTable(
                name: "DepartmentRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    InternalRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentRoles_AppDepartmentInternalRole_InternalRoleId",
                        column: x => x.InternalRoleId,
                        principalTable: "AppDepartmentInternalRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentRoles_AppDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRoles_DepartmentId",
                table: "DepartmentRoles",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRoles_InternalRoleId",
                table: "DepartmentRoles",
                column: "InternalRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppDepartmentSkill_AppDepartment_departmentId",
                table: "AppDepartmentSkill",
                column: "departmentId",
                principalTable: "AppDepartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDepartmentSkill_AppDepartment_departmentId",
                table: "AppDepartmentSkill");

            migrationBuilder.DropTable(
                name: "DepartmentRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_RoleId_DepartmentId",
                table: "AppRoleDepartment",
                columns: new[] { "RoleId", "DepartmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_DeleterId_SkillId",
                table: "AppDepartmentSkill",
                columns: new[] { "DeleterId", "SkillId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppDepartmentSkill_AppDepartment_DeleterId",
                table: "AppDepartmentSkill",
                column: "DeleterId",
                principalTable: "AppDepartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
