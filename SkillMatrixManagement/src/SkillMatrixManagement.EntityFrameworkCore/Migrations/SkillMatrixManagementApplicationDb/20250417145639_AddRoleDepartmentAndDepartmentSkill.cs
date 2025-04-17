using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class AddRoleDepartmentAndDepartmentSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDepartmentRole");

            migrationBuilder.CreateTable(
                name: "AppDepartmentSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    departmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillName = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppDepartmentSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDepartmentSkill_AppDepartment_DeleterId",
                        column: x => x.DeleterId,
                        principalTable: "AppDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppDepartmentSkill_AppSkill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "AppSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppRoleDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleDepartment_AppDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRoleDepartment_AppRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_ConcurrencyStamp",
                table: "AppDepartmentSkill",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_CreationTime",
                table: "AppDepartmentSkill",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_CreatorId",
                table: "AppDepartmentSkill",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_DeleterId",
                table: "AppDepartmentSkill",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_DeleterId_SkillId",
                table: "AppDepartmentSkill",
                columns: new[] { "DeleterId", "SkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_DeletionTime",
                table: "AppDepartmentSkill",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_departmentId",
                table: "AppDepartmentSkill",
                column: "departmentId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_DepartmentName",
                table: "AppDepartmentSkill",
                column: "DepartmentName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_ExtraProperties",
                table: "AppDepartmentSkill",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_Id",
                table: "AppDepartmentSkill",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_IsDeleted",
                table: "AppDepartmentSkill",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_LastModificationTime",
                table: "AppDepartmentSkill",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_LastModifierId",
                table: "AppDepartmentSkill",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_SkillId",
                table: "AppDepartmentSkill",
                column: "SkillId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentSkill_SkillName",
                table: "AppDepartmentSkill",
                column: "SkillName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_ConcurrencyStamp",
                table: "AppRoleDepartment",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_CreationTime",
                table: "AppRoleDepartment",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_CreatorId",
                table: "AppRoleDepartment",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_DeleterId",
                table: "AppRoleDepartment",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_DeletionTime",
                table: "AppRoleDepartment",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_DepartmentId",
                table: "AppRoleDepartment",
                column: "DepartmentId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_DepartmentName",
                table: "AppRoleDepartment",
                column: "DepartmentName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_ExtraProperties",
                table: "AppRoleDepartment",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_Id",
                table: "AppRoleDepartment",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_IsDeleted",
                table: "AppRoleDepartment",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_LastModificationTime",
                table: "AppRoleDepartment",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_LastModifierId",
                table: "AppRoleDepartment",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_RoleId",
                table: "AppRoleDepartment",
                column: "RoleId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_RoleId_DepartmentId",
                table: "AppRoleDepartment",
                columns: new[] { "RoleId", "DepartmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleDepartment_RoleName",
                table: "AppRoleDepartment",
                column: "RoleName")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDepartmentSkill");

            migrationBuilder.DropTable(
                name: "AppRoleDepartment");

            migrationBuilder.CreateTable(
                name: "AppDepartmentRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    InternalRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDepartmentRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDepartmentRole_AppDepartmentInternalRole_InternalRoleId",
                        column: x => x.InternalRoleId,
                        principalTable: "AppDepartmentInternalRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppDepartmentRole_AppDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_ConcurrencyStamp",
                table: "AppDepartmentRole",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_CreationTime",
                table: "AppDepartmentRole",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_CreatorId",
                table: "AppDepartmentRole",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_DeleterId",
                table: "AppDepartmentRole",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_DeletionTime",
                table: "AppDepartmentRole",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_DepartmentId",
                table: "AppDepartmentRole",
                column: "DepartmentId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_ExtraProperties",
                table: "AppDepartmentRole",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_Id",
                table: "AppDepartmentRole",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_InternalRoleId",
                table: "AppDepartmentRole",
                column: "InternalRoleId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_IsDeleted",
                table: "AppDepartmentRole",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_LastModificationTime",
                table: "AppDepartmentRole",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentRole_LastModifierId",
                table: "AppDepartmentRole",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }
    }
}
