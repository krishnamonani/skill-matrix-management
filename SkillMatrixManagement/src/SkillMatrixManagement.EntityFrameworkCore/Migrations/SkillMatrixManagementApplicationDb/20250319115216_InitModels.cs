using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using SkillMatrixManagement.Constants;

#nullable disable

namespace SkillMatrixManagement.Migrations.SkillMatrixManagementApplicationDb
{
    /// <inheritdoc />
    public partial class InitModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsUpdated = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_AppCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppDepartmentInternalRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RoleDescription = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_AppDepartmentInternalRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppProficiencyLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppProficiencyLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDelayed = table.Column<bool>(type: "boolean", nullable: false),
                    IsOngoing = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_AppProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppDepartmentRole",
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

            migrationBuilder.CreateTable(
                name: "AppSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSkill_AppCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AppCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSkill_AppDepartmentInternalRole_InternalRoleId",
                        column: x => x.InternalRoleId,
                        principalTable: "AppDepartmentInternalRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    InternalRoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_AppDepartmentInternalRole_InternalRoleId",
                        column: x => x.InternalRoleId,
                        principalTable: "AppDepartmentInternalRole",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUser_AppDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUser_AppRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppSkillMatrix",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpectedProficiencyId = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppSkillMatrix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSkillMatrix_AppDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSkillMatrix_AppSkill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "AppSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppSkillSubtopic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ReqExpertiseLevelId = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppSkillSubtopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSkillSubtopic_AppSkill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "AppSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppDepartmentManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_AppDepartmentManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDepartmentManager_AppDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppDepartmentManager_AppUser_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppEmployeeSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    SelfAssessedProficiency = table.Column<string>(type: "text", nullable: false),
                    ManagerAssignedProficiency = table.Column<string>(type: "text", nullable: true),
                    EndorsedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    EndorserId = table.Column<Guid>(type: "uuid", nullable: false),
                    EndorsedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SkillDescription = table.Column<Dictionary<string, ProficiencyEnum>>(type: "jsonb", nullable: false),
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
                    table.PrimaryKey("PK_AppEmployeeSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppEmployeeSkill_AppSkill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "AppSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppEmployeeSkill_AppUser_EndorserId",
                        column: x => x.EndorserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppEmployeeSkill_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    IsQueued = table.Column<bool>(type: "boolean", nullable: false),
                    IsDelivered = table.Column<bool>(type: "boolean", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    table.PrimaryKey("PK_AppNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppNotification_AppDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppNotification_AppUser_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppProjectEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_AppProjectEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppProjectEmployee_AppProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "AppProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppProjectEmployee_AppUser_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppProjectEmployee_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppReportAnalytics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportType = table.Column<string>(type: "text", nullable: false),
                    GeneratedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneratedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataSnapshot = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: false),
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
                    table.PrimaryKey("PK_AppReportAnalytics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppReportAnalytics_AppUser_GeneratedByUserId",
                        column: x => x.GeneratedByUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppSkillHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChangedProficiencyLevel = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    UserIdBasedVersion = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_AppSkillHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSkillHistory_AppSkill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "AppSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSkillHistory_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppSkillRecommendation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecommendedSkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConfidenceScore = table.Column<float>(type: "real", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AlgorithmUsed = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_AppSkillRecommendation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSkillRecommendation_AppSkill_RecommendedSkillId",
                        column: x => x.RecommendedSkillId,
                        principalTable: "AppSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSkillRecommendation_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppSkillRecommendationByManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillRecommenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AppSkillRecommendationByManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSkillRecommendationByManager_AppSkill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "AppSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSkillRecommendationByManager_AppUser_SkillRecommenderId",
                        column: x => x.SkillRecommenderId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSkillRecommendationByManager_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_CategoryName",
                table: "AppCategory",
                column: "CategoryName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_ConcurrencyStamp",
                table: "AppCategory",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_CreationTime",
                table: "AppCategory",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_CreatorId",
                table: "AppCategory",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_DeleterId",
                table: "AppCategory",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_DeletionTime",
                table: "AppCategory",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_Description",
                table: "AppCategory",
                column: "Description")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_ExtraProperties",
                table: "AppCategory",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_Id",
                table: "AppCategory",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_IsDeleted",
                table: "AppCategory",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_IsUpdated",
                table: "AppCategory",
                column: "IsUpdated")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_LastModificationTime",
                table: "AppCategory",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategory_LastModifierId",
                table: "AppCategory",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_ConcurrencyStamp",
                table: "AppDepartment",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_CreationTime",
                table: "AppDepartment",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_CreatorId",
                table: "AppDepartment",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_DeleterId",
                table: "AppDepartment",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_DeletionTime",
                table: "AppDepartment",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_Description",
                table: "AppDepartment",
                column: "Description")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_ExtraProperties",
                table: "AppDepartment",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_Id",
                table: "AppDepartment",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_IsDeleted",
                table: "AppDepartment",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_LastModificationTime",
                table: "AppDepartment",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_LastModifierId",
                table: "AppDepartment",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartment_Name",
                table: "AppDepartment",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_ConcurrencyStamp",
                table: "AppDepartmentInternalRole",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_CreationTime",
                table: "AppDepartmentInternalRole",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_CreatorId",
                table: "AppDepartmentInternalRole",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_DeleterId",
                table: "AppDepartmentInternalRole",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_DeletionTime",
                table: "AppDepartmentInternalRole",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_ExtraProperties",
                table: "AppDepartmentInternalRole",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_Id",
                table: "AppDepartmentInternalRole",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_IsDeleted",
                table: "AppDepartmentInternalRole",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_LastModificationTime",
                table: "AppDepartmentInternalRole",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_LastModifierId",
                table: "AppDepartmentInternalRole",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_Position",
                table: "AppDepartmentInternalRole",
                column: "Position")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_RoleDescription",
                table: "AppDepartmentInternalRole",
                column: "RoleDescription")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentInternalRole_RoleName",
                table: "AppDepartmentInternalRole",
                column: "RoleName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_ConcurrencyStamp",
                table: "AppDepartmentManager",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_CreationTime",
                table: "AppDepartmentManager",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_CreatorId",
                table: "AppDepartmentManager",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_DeleterId",
                table: "AppDepartmentManager",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_DeletionTime",
                table: "AppDepartmentManager",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_DepartmentId",
                table: "AppDepartmentManager",
                column: "DepartmentId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_ExtraProperties",
                table: "AppDepartmentManager",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_Id",
                table: "AppDepartmentManager",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_IsDeleted",
                table: "AppDepartmentManager",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_LastModificationTime",
                table: "AppDepartmentManager",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_LastModifierId",
                table: "AppDepartmentManager",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentManager_ManagerId",
                table: "AppDepartmentManager",
                column: "ManagerId")
                .Annotation("Npgsql:IndexMethod", "HASH");

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

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_ConcurrencyStamp",
                table: "AppEmployeeSkill",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_CreationTime",
                table: "AppEmployeeSkill",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_CreatorId",
                table: "AppEmployeeSkill",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_DeleterId",
                table: "AppEmployeeSkill",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_DeletionTime",
                table: "AppEmployeeSkill",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_EndorsedAt",
                table: "AppEmployeeSkill",
                column: "EndorsedAt")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_EndorsedBy",
                table: "AppEmployeeSkill",
                column: "EndorsedBy")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_EndorserId",
                table: "AppEmployeeSkill",
                column: "EndorserId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_ExtraProperties",
                table: "AppEmployeeSkill",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_Id",
                table: "AppEmployeeSkill",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_IsDeleted",
                table: "AppEmployeeSkill",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_LastModificationTime",
                table: "AppEmployeeSkill",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_LastModifierId",
                table: "AppEmployeeSkill",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_ManagerAssignedProficiency",
                table: "AppEmployeeSkill",
                column: "ManagerAssignedProficiency")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_SelfAssessedProficiency",
                table: "AppEmployeeSkill",
                column: "SelfAssessedProficiency")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_SkillDescription",
                table: "AppEmployeeSkill",
                column: "SkillDescription")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_SkillId",
                table: "AppEmployeeSkill",
                column: "SkillId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployeeSkill_UserId",
                table: "AppEmployeeSkill",
                column: "UserId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_ConcurrencyStamp",
                table: "AppNotification",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_CreatedBy",
                table: "AppNotification",
                column: "CreatedBy")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_CreationTime",
                table: "AppNotification",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_CreatorId",
                table: "AppNotification",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_DeleterId",
                table: "AppNotification",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_DeletionTime",
                table: "AppNotification",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_DeliveredAt",
                table: "AppNotification",
                column: "DeliveredAt")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_DepartmentId",
                table: "AppNotification",
                column: "DepartmentId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_Description",
                table: "AppNotification",
                column: "Description")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_ExtraProperties",
                table: "AppNotification",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_Id",
                table: "AppNotification",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_IsDeleted",
                table: "AppNotification",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_IsDelivered",
                table: "AppNotification",
                column: "IsDelivered")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_IsQueued",
                table: "AppNotification",
                column: "IsQueued")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_LastModificationTime",
                table: "AppNotification",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_LastModifierId",
                table: "AppNotification",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_NotificationName",
                table: "AppNotification",
                column: "NotificationName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_ConcurrencyStamp",
                table: "AppPermission",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_CreationTime",
                table: "AppPermission",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_CreatorId",
                table: "AppPermission",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_DeleterId",
                table: "AppPermission",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_DeletionTime",
                table: "AppPermission",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_Description",
                table: "AppPermission",
                column: "Description")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_ExtraProperties",
                table: "AppPermission",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_Id",
                table: "AppPermission",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_IsDeleted",
                table: "AppPermission",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_LastModificationTime",
                table: "AppPermission",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_LastModifierId",
                table: "AppPermission",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermission_Name",
                table: "AppPermission",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_ConcurrencyStamp",
                table: "AppProjectEmployee",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_CreatedBy",
                table: "AppProjectEmployee",
                column: "CreatedBy")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_CreationTime",
                table: "AppProjectEmployee",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_CreatorId",
                table: "AppProjectEmployee",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_DeleterId",
                table: "AppProjectEmployee",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_DeletionTime",
                table: "AppProjectEmployee",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_ExtraProperties",
                table: "AppProjectEmployee",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_Id",
                table: "AppProjectEmployee",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_IsDeleted",
                table: "AppProjectEmployee",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_LastModificationTime",
                table: "AppProjectEmployee",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_LastModifierId",
                table: "AppProjectEmployee",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_ProjectId",
                table: "AppProjectEmployee",
                column: "ProjectId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectEmployee_UserId",
                table: "AppProjectEmployee",
                column: "UserId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_ConcurrencyStamp",
                table: "AppReportAnalytics",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_CreationTime",
                table: "AppReportAnalytics",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_CreatorId",
                table: "AppReportAnalytics",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_DataSnapshot",
                table: "AppReportAnalytics",
                column: "DataSnapshot")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_DeleterId",
                table: "AppReportAnalytics",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_DeletionTime",
                table: "AppReportAnalytics",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_ExtraProperties",
                table: "AppReportAnalytics",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_GeneratedAt",
                table: "AppReportAnalytics",
                column: "GeneratedAt")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_GeneratedBy",
                table: "AppReportAnalytics",
                column: "GeneratedBy")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_GeneratedByUserId",
                table: "AppReportAnalytics",
                column: "GeneratedByUserId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_Id",
                table: "AppReportAnalytics",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_IsDeleted",
                table: "AppReportAnalytics",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_LastModificationTime",
                table: "AppReportAnalytics",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_LastModifierId",
                table: "AppReportAnalytics",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppReportAnalytics_ReportType",
                table: "AppReportAnalytics",
                column: "ReportType")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_ConcurrencyStamp",
                table: "AppRole",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_CreationTime",
                table: "AppRole",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_CreatorId",
                table: "AppRole",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_DeleterId",
                table: "AppRole",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_DeletionTime",
                table: "AppRole",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_ExtraProperties",
                table: "AppRole",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_Id",
                table: "AppRole",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_IsDeleted",
                table: "AppRole",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_LastModificationTime",
                table: "AppRole",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_LastModifierId",
                table: "AppRole",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_Name",
                table: "AppRole",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_CategoryId",
                table: "AppSkill",
                column: "CategoryId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_ConcurrencyStamp",
                table: "AppSkill",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_CreationTime",
                table: "AppSkill",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_CreatorId",
                table: "AppSkill",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_DeleterId",
                table: "AppSkill",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_DeletionTime",
                table: "AppSkill",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_Description",
                table: "AppSkill",
                column: "Description")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_ExtraProperties",
                table: "AppSkill",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_Id",
                table: "AppSkill",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_InternalRoleId",
                table: "AppSkill",
                column: "InternalRoleId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_IsDeleted",
                table: "AppSkill",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_LastModificationTime",
                table: "AppSkill",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_LastModifierId",
                table: "AppSkill",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkill_Name",
                table: "AppSkill",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_ChangedProficiencyLevel",
                table: "AppSkillHistory",
                column: "ChangedProficiencyLevel")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_Comment",
                table: "AppSkillHistory",
                column: "Comment")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_ConcurrencyStamp",
                table: "AppSkillHistory",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_CreationTime",
                table: "AppSkillHistory",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_CreatorId",
                table: "AppSkillHistory",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_DeleterId",
                table: "AppSkillHistory",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_DeletionTime",
                table: "AppSkillHistory",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_ExtraProperties",
                table: "AppSkillHistory",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_Id",
                table: "AppSkillHistory",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_IsDeleted",
                table: "AppSkillHistory",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_LastModificationTime",
                table: "AppSkillHistory",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_LastModifierId",
                table: "AppSkillHistory",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_SkillId",
                table: "AppSkillHistory",
                column: "SkillId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_UserId",
                table: "AppSkillHistory",
                column: "UserId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillHistory_UserIdBasedVersion",
                table: "AppSkillHistory",
                column: "UserIdBasedVersion")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_ConcurrencyStamp",
                table: "AppSkillMatrix",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_CreationTime",
                table: "AppSkillMatrix",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_CreatorId",
                table: "AppSkillMatrix",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_DeleterId",
                table: "AppSkillMatrix",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_DeletionTime",
                table: "AppSkillMatrix",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_DepartmentId",
                table: "AppSkillMatrix",
                column: "DepartmentId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_ExpectedProficiencyId",
                table: "AppSkillMatrix",
                column: "ExpectedProficiencyId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_ExtraProperties",
                table: "AppSkillMatrix",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_Id",
                table: "AppSkillMatrix",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_IsDeleted",
                table: "AppSkillMatrix",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_LastModificationTime",
                table: "AppSkillMatrix",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_LastModifierId",
                table: "AppSkillMatrix",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillMatrix_SkillId",
                table: "AppSkillMatrix",
                column: "SkillId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_AlgorithmUsed",
                table: "AppSkillRecommendation",
                column: "AlgorithmUsed")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_ConcurrencyStamp",
                table: "AppSkillRecommendation",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_ConfidenceScore",
                table: "AppSkillRecommendation",
                column: "ConfidenceScore")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_CreationTime",
                table: "AppSkillRecommendation",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_CreatorId",
                table: "AppSkillRecommendation",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_DeleterId",
                table: "AppSkillRecommendation",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_DeletionTime",
                table: "AppSkillRecommendation",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_ExtraProperties",
                table: "AppSkillRecommendation",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_GeneratedAt",
                table: "AppSkillRecommendation",
                column: "GeneratedAt")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_Id",
                table: "AppSkillRecommendation",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_IsDeleted",
                table: "AppSkillRecommendation",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_LastModificationTime",
                table: "AppSkillRecommendation",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_LastModifierId",
                table: "AppSkillRecommendation",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_RecommendedSkillId",
                table: "AppSkillRecommendation",
                column: "RecommendedSkillId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendation_UserId",
                table: "AppSkillRecommendation",
                column: "UserId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_Comment",
                table: "AppSkillRecommendationByManager",
                column: "Comment")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_ConcurrencyStamp",
                table: "AppSkillRecommendationByManager",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_CreationTime",
                table: "AppSkillRecommendationByManager",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_CreatorId",
                table: "AppSkillRecommendationByManager",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_DeleterId",
                table: "AppSkillRecommendationByManager",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_DeletionTime",
                table: "AppSkillRecommendationByManager",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_ExtraProperties",
                table: "AppSkillRecommendationByManager",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_Id",
                table: "AppSkillRecommendationByManager",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_IsDeleted",
                table: "AppSkillRecommendationByManager",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_LastModificationTime",
                table: "AppSkillRecommendationByManager",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_LastModifierId",
                table: "AppSkillRecommendationByManager",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_SkillId",
                table: "AppSkillRecommendationByManager",
                column: "SkillId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_SkillRecommenderId",
                table: "AppSkillRecommendationByManager",
                column: "SkillRecommenderId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillRecommendationByManager_UserId",
                table: "AppSkillRecommendationByManager",
                column: "UserId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_ConcurrencyStamp",
                table: "AppSkillSubtopic",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_CreationTime",
                table: "AppSkillSubtopic",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_CreatorId",
                table: "AppSkillSubtopic",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_DeleterId",
                table: "AppSkillSubtopic",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_DeletionTime",
                table: "AppSkillSubtopic",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_Description",
                table: "AppSkillSubtopic",
                column: "Description")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_ExtraProperties",
                table: "AppSkillSubtopic",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_Id",
                table: "AppSkillSubtopic",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_IsDeleted",
                table: "AppSkillSubtopic",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_LastModificationTime",
                table: "AppSkillSubtopic",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_LastModifierId",
                table: "AppSkillSubtopic",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_Name",
                table: "AppSkillSubtopic",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_ReqExpertiseLevelId",
                table: "AppSkillSubtopic",
                column: "ReqExpertiseLevelId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppSkillSubtopic_SkillId",
                table: "AppSkillSubtopic",
                column: "SkillId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_ConcurrencyStamp",
                table: "AppUser",
                column: "ConcurrencyStamp")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_CreationTime",
                table: "AppUser",
                column: "CreationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_CreatorId",
                table: "AppUser",
                column: "CreatorId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_DeleterId",
                table: "AppUser",
                column: "DeleterId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_DeletionTime",
                table: "AppUser",
                column: "DeletionTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_DepartmentId",
                table: "AppUser",
                column: "DepartmentId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Email",
                table: "AppUser",
                column: "Email")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_ExtraProperties",
                table: "AppUser",
                column: "ExtraProperties")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_FirstName",
                table: "AppUser",
                column: "FirstName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Id",
                table: "AppUser",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_InternalRoleId",
                table: "AppUser",
                column: "InternalRoleId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_IsAvailable",
                table: "AppUser",
                column: "IsAvailable")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_IsDeleted",
                table: "AppUser",
                column: "IsDeleted")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_LastModificationTime",
                table: "AppUser",
                column: "LastModificationTime")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_LastModifierId",
                table: "AppUser",
                column: "LastModifierId")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_LastName",
                table: "AppUser",
                column: "LastName")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_PhoneNumber",
                table: "AppUser",
                column: "PhoneNumber")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_ProfilePhoto",
                table: "AppUser",
                column: "ProfilePhoto")
                .Annotation("Npgsql:IndexMethod", "HASH");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_RoleId",
                table: "AppUser",
                column: "RoleId")
                .Annotation("Npgsql:IndexMethod", "HASH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDepartmentManager");

            migrationBuilder.DropTable(
                name: "AppDepartmentRole");

            migrationBuilder.DropTable(
                name: "AppEmployeeSkill");

            migrationBuilder.DropTable(
                name: "AppNotification");

            migrationBuilder.DropTable(
                name: "AppPermission");

            migrationBuilder.DropTable(
                name: "AppProficiencyLevel");

            migrationBuilder.DropTable(
                name: "AppProjectEmployee");

            migrationBuilder.DropTable(
                name: "AppReportAnalytics");

            migrationBuilder.DropTable(
                name: "AppSkillHistory");

            migrationBuilder.DropTable(
                name: "AppSkillMatrix");

            migrationBuilder.DropTable(
                name: "AppSkillRecommendation");

            migrationBuilder.DropTable(
                name: "AppSkillRecommendationByManager");

            migrationBuilder.DropTable(
                name: "AppSkillSubtopic");

            migrationBuilder.DropTable(
                name: "AppProject");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "AppSkill");

            migrationBuilder.DropTable(
                name: "AppDepartment");

            migrationBuilder.DropTable(
                name: "AppRole");

            migrationBuilder.DropTable(
                name: "AppCategory");

            migrationBuilder.DropTable(
                name: "AppDepartmentInternalRole");
        }
    }
}
