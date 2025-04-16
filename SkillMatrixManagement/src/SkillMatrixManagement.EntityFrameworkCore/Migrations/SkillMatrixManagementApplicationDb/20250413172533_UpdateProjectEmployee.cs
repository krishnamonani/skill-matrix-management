﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateProjectEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppProjectEmployee_CreatedBy",
                table: "AppProjectEmployee");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AppProjectEmployee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "AppProjectEmployee",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_CreatedBy",
                table: "AppProjectEmployee",
                column: "CreatedBy")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }
    }
}
