using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.Domain;
using SkillMatrixManagement.Models;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace SkillMatrixManagement.EntityFrameworkCore
{
    [ConnectionStringName("ApplicationDb")]
    public class SkillMatrixManagementApplicationDbContext : AbpDbContext<SkillMatrixManagementApplicationDbContext>
    {
        public SkillMatrixManagementApplicationDbContext(DbContextOptions<SkillMatrixManagementApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<SkillRecommendationByManager> SkillRecommendationByManagers { get; set; }
        public DbSet<SkillHistory> SkillHistories { get; set; }
        public DbSet<SkillSubtopic> SkillSubtopics { get; set; }
        public DbSet<SkillRecommendation> SkillRecommendations { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<SkillMatrix> SkillMatrixs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProficiencyLevel> ProficiencyLevels { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<ReportAnalytics> ReportAnalyticss { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DepartmentManager> DepartmentManagers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<DepartmentRole> DepartmentRoles { get; set; }
        public DbSet<DepartmentInternalRole> DepartmentInternalRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */


            /* Configure your own tables/entities inside here */

            // Configure Role entity
            builder.Entity<Role>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "Role", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasIndex(r => r.Name).IsUnique();

                b.Property(r => r.Name)
                .HasConversion(
                    v => v.ToString(), // Convert enum to string when saving
                    v => (RoleEnum)Enum.Parse(typeof(RoleEnum), v) // Convert string back to enum when reading
                );
            });

            // Configure User entity
            builder.Entity<User>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "User", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(r => r.IsAvailable)
                .HasConversion(
                    v => v.ToString(), // Convert enum to string when saving
                    v => (ProjectStatusEnum)Enum.Parse(typeof(ProjectStatusEnum), v) // Convert string back to enum when reading
                );
            });

            // Configure SkillRecommendationByManager entity
            builder.Entity<SkillRecommendationByManager>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "SkillRecommendationByManager", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();
            });

            // Configure SkillHistory entity
            builder.Entity<SkillHistory>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "SkillHistory", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(r => r.ChangedProficiencyLevel)
               .HasConversion(
                   v => v.ToString(), // Convert enum to string when saving
                   v => (ProficiencyEnum)Enum.Parse(typeof(ProficiencyEnum), v) // Convert string back to enum when reading
               );
            });

            // Configure SkillSubtopic entity
            builder.Entity<SkillSubtopic>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "SkillSubtopic", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(e => e.Description)
                    .HasColumnType("jsonb")
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null), // Serialize to JSON
                        v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions?)null), // Deserialize from JSON
                        new ValueComparer<Dictionary<string, string>>(
                            (c1, c2) => c1!.SequenceEqual(c2!),
                            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                            c => c.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                        )
                    );

                b.Property(r => r.ReqExpertiseLevelId)
               .HasConversion(
                   v => v.ToString(), // Convert enum to string when saving
                   v => (ProficiencyEnum)Enum.Parse(typeof(ProficiencyEnum), v) // Convert string back to enum when reading
               );
            });

            // Configure SkillRecommendation entity
            builder.Entity<SkillRecommendation>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "SkillRecommendation", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();
            });

            // Configure EmployeeSkill entity
            builder.Entity<EmployeeSkill>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "EmployeeSkill", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasOne(e => e.User)
                .WithMany(u => u.EmployeeSkills)
                .HasForeignKey(e => e.UserId);

                b.Property(r => r.SelfAssessedProficiency)
                .HasConversion(
                    v => v.ToString(), // Convert enum to string when saving
                    v => (ProficiencyEnum)Enum.Parse(typeof(ProficiencyEnum), v) // Convert string back to enum when reading
                );

                b.Property(r => r.ManagerAssignedProficiency)
                .HasConversion(
                    v => v.ToString(), // Convert enum to string when saving
                    v => (ProficiencyEnum)Enum.Parse(typeof(ProficiencyEnum), v) // Convert string back to enum when reading
                );
                b.HasOne(e => e.Endorser) // Define relationship with User
                .WithMany() // No navigation property required on User side
                .HasForeignKey(e => e.EndorsedBy) // Set foreign key
                .OnDelete(DeleteBehavior.SetNull); // Allow NULL values on delete

                b.Property(e => e.EndorsedBy)
                .IsRequired(false); // Explicitly make it nullable


                //b.Property(e => e.SkillDescription)
                //.HasColumnType("jsonb");
            });

            // Configure SkillMatrix entity
            builder.Entity<SkillMatrix>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "SkillMatrix", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(r => r.ExpectedProficiencyId)
                .HasConversion(
                    v => v.ToString(), // Convert enum to string when saving
                    v => (ProficiencyEnum)Enum.Parse(typeof(ProficiencyEnum), v) // Convert string back to enum when reading
                );
            });

            // Configure Skill entity
            builder.Entity<Skill>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "Skill", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();
            });

            // Configure ProficiencyLevel entity
            builder.Entity<ProficiencyLevel>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "ProficiencyLevel", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasIndex(r => r.Level).IsUnique();

                b.Property(r => r.Level)
               .HasConversion(
                   v => v.ToString(), // Convert enum to string when saving
                   v => (ProficiencyEnum)Enum.Parse(typeof(ProficiencyEnum), v) // Convert string back to enum when reading
               );
            });

            // Configure ProjectEmployee entity
            builder.Entity<ProjectEmployee>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "ProjectEmployee", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();
            });

            // Configure ReportAnalytics entity
            builder.Entity<ReportAnalytics>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "ReportAnalytics", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasIndex(r => r.ReportType).IsUnique();

                b.Property(e => e.DataSnapshot)
                .HasColumnType("jsonb");

                b.Property(r => r.ReportType)
               .HasConversion(
                   v => v.ToString(), // Convert enum to string when saving
                   v => (ReportTypeEnum)Enum.Parse(typeof(ReportTypeEnum), v) // Convert string back to enum when reading
               );
            });

            // Configure Category entity
            builder.Entity<Category>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "Category", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasIndex(r => r.CategoryName).IsUnique();

                b.Property(r => r.CategoryName)
                .HasConversion(
                       v => v.ToString(), // Convert enum to string when saving
                       v => (CategoryEnum)Enum.Parse(typeof(CategoryEnum), v) // Convert string back to enum when reading
                );
            });

            // Configure Notification entity
            builder.Entity<Notification>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "Notification", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();
            });

            // Configure DepartmentManager entity
            builder.Entity<DepartmentManager>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "DepartmentManager", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();
            });

            // Configure Project entity
            builder.Entity<Project>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "Project", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();
            });


            // Configure Department entity
            builder.Entity<Department>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "Department", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasIndex(r => r.Name).IsUnique();
            });

            // Configure Permission entity
            builder.Entity<Permission>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "Permission", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasIndex(r => r.Name).IsUnique();

                b.Property(r => r.Name)
                .HasConversion(
                       v => v.ToString(), // Convert enum to string when saving
                       v => (PermissionEnum)Enum.Parse(typeof(PermissionEnum), v) // Convert string back to enum when reading
                );
            });

            // Configure DepartmentRole entity
            builder.Entity<DepartmentRole>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "DepartmentRole", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();
            });

            // Configure DepartmentInternalRole entity
            builder.Entity<DepartmentInternalRole>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "DepartmentInternalRole", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasIndex(r => r.RoleName).IsUnique();

                b.Property(r => r.RoleName)
                .HasConversion(
                       v => v.ToString(), // Convert enum to string when saving
                       v => (DepartmentRoleEnum)Enum.Parse(typeof(DepartmentRoleEnum), v) // Convert string back to enum when reading
                );

                b.Property(r => r.Position)
               .HasConversion(
                      v => v.ToString(), // Convert enum to string when saving
                      v => (RolePositionEnum)Enum.Parse(typeof(RolePositionEnum), v) // Convert string back to enum when reading
               );
            });

            // Configure RolePermission entity
            builder.Entity<RolePermission>(b =>
            {
                b.ToTable(SkillMatrixManagementConsts.DbTablePrefix + "RolePermission", SkillMatrixManagementConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<CustomUser>(b =>
                        {
                            b.ToTable("CustomUsers");
                            b.ConfigureByConvention();
                            b.HasKey(x => x.Id);
                            b.Property(x => x.IdentityUserId).IsRequired();
                            b.Property(x => x.UserName).IsRequired().HasMaxLength(256);
                            b.Property(x => x.Email).IsRequired().HasMaxLength(256);
                            b.Property(x => x.IsActive).IsRequired();
                        });
            /* implementing hash index for the columns used frequently */
            AddHashIndexesForAllColumns<User>(builder);
            AddHashIndexesForAllColumns<SkillSubtopic>(builder);
            AddHashIndexesForAllColumns<SkillRecommendationByManager>(builder);
            AddHashIndexesForAllColumns<SkillRecommendation>(builder);
            AddHashIndexesForAllColumns<SkillMatrix>(builder);
            AddHashIndexesForAllColumns<SkillHistory>(builder);
            AddHashIndexesForAllColumns<Skill>(builder);
            AddHashIndexesForAllColumns<RolePermission>(builder);
            AddHashIndexesForAllColumns<ReportAnalytics>(builder);
            AddHashIndexesForAllColumns<ProjectEmployee>(builder);
            AddHashIndexesForAllColumns<Permission>(builder);
            AddHashIndexesForAllColumns<Notification>(builder);
            AddHashIndexesForAllColumns<EmployeeSkill>(builder);
            AddHashIndexesForAllColumns<DepartmentRole>(builder);
            AddHashIndexesForAllColumns<DepartmentManager>(builder);
            AddHashIndexesForAllColumns<DepartmentInternalRole>(builder);
            AddHashIndexesForAllColumns<Department>(builder);
            AddHashIndexesForAllColumns<Category>(builder);
            AddHashIndexesForAllColumns<Role>(builder);


        }

        private void AddHashIndexesForAllColumns<TEntity>(ModelBuilder builder) where TEntity : class
        {
            var entityType = builder.Model.FindEntityType(typeof(TEntity));
            if (entityType == null) return;
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                builder.Entity<TEntity>()
                    .HasIndex(property.Name)
                    .HasMethod("HASH");
            }
        }

    }
}
