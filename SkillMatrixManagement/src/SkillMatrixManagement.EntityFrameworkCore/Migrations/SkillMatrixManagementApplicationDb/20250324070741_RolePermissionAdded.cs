using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class RolePermissionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRolePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_AppRolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRolePermission_AppPermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "AppPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRolePermission_AppRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_ConcurrencyStamp",
                table: "AppRolePermission",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_CreationTime",
                table: "AppRolePermission",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_CreatorId",
                table: "AppRolePermission",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_DeleterId",
                table: "AppRolePermission",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_DeletionTime",
                table: "AppRolePermission",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_ExtraProperties",
                table: "AppRolePermission",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_Id",
                table: "AppRolePermission",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_IsDeleted",
                table: "AppRolePermission",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_LastModificationTime",
                table: "AppRolePermission",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_LastModifierId",
                table: "AppRolePermission",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_PermissionId",
                table: "AppRolePermission",
                column: "PermissionId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_RoleId",
                table: "AppRolePermission",
                column: "RoleId")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRolePermission");
        }
    }
}
