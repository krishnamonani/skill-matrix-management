using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateConstraintToReqModelUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppRole_Name",
                table: "AppRole");

            migrationBuilder.DropIndex(
                name: "IX_AppReportAnalytics_ReportType",
                table: "AppReportAnalytics");

            migrationBuilder.DropIndex(
                name: "IX_AppPermission_Name",
                table: "AppPermission");

            migrationBuilder.DropIndex(
                name: "IX_AppDepartmentInternalRole_RoleName",
                table: "AppDepartmentInternalRole");

            migrationBuilder.DropIndex(
                name: "IX_AppDepartment_Name",
                table: "AppDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AppCategory_CategoryName",
                table: "AppCategory");

            migrationBuilder.AlterColumn<string>(
                name: "NotificationName",
                table: "AppNotification",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_Name",
                table: "AppRole",
                column: "Name",
                unique: true)
                /*.Annotation("Npgsql:IndexMethod", "HASH")*/;

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_ReportType",
                table: "AppReportAnalytics",
                column: "ReportType",
                unique: true)
                /*.Annotation("Npgsql:IndexMethod", "HASH")*/;

            migrationBuilder.CreateIndex(
                name: "IX_AppProficiencyLevel_Level",
                table: "AppProficiencyLevel",
                column: "Level",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_Name",
                table: "AppPermission",
                column: "Name",
                unique: true)
                /*.Annotation("Npgsql:IndexMethod", "HASH")*/;

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_RoleName",
                table: "AppDepartmentInternalRole",
                column: "RoleName",
                unique: true)
                /*.Annotation("Npgsql:IndexMethod", "HASH")*/;

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_Name",
                table: "AppDepartment",
                column: "Name",
                unique: true)
                /*.Annotation("Npgsql:IndexMethod", "HASH")*/;

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_CategoryName",
                table: "AppCategory",
                column: "CategoryName",
                unique: true)
                /*.Annotation("Npgsql:IndexMethod", "HASH")*/;
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppRole_Name",
                table: "AppRole");

            migrationBuilder.DropIndex(
                name: "IX_AppReportAnalytics_ReportType",
                table: "AppReportAnalytics");

            migrationBuilder.DropIndex(
                name: "IX_AppProficiencyLevel_Level",
                table: "AppProficiencyLevel");

            migrationBuilder.DropIndex(
                name: "IX_AppPermission_Name",
                table: "AppPermission");

            migrationBuilder.DropIndex(
                name: "IX_AppDepartmentInternalRole_RoleName",
                table: "AppDepartmentInternalRole");

            migrationBuilder.DropIndex(
                name: "IX_AppDepartment_Name",
                table: "AppDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AppCategory_CategoryName",
                table: "AppCategory");

            migrationBuilder.AlterColumn<string>(
                name: "NotificationName",
                table: "AppNotification",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_Name",
                table: "AppRole",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_ReportType",
                table: "AppReportAnalytics",
                column: "ReportType")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_Name",
                table: "AppPermission",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_RoleName",
                table: "AppDepartmentInternalRole",
                column: "RoleName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_Name",
                table: "AppDepartment",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_CategoryName",
                table: "AppCategory",
                column: "CategoryName")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }
    }
}
