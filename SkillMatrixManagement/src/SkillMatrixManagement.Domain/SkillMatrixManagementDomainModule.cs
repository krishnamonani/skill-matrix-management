using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SkillMatrixManagement.Localization;
using SkillMatrixManagement.MultiTenancy;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.SettingManagement;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.Caching;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement.OpenIddict;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;
using SkillMatrixManagement.CustomDataSeeding;
using Volo.Abp.Data;
using System.ComponentModel.Design.Serialization;
using Volo.Abp.TextTemplating;
using Volo.Abp.TextTemplating.Razor;
using Volo.Abp.VirtualFileSystem;

namespace SkillMatrixManagement;

[DependsOn(
    typeof(SkillMatrixManagementDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpCachingModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpEmailingModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpOpenIddictDomainModule),
    typeof(AbpTenantManagementDomainModule),
    typeof(BlobStoringDatabaseDomainModule),
    typeof(AbpTextTemplatingRazorModule)
    )]
public class SkillMatrixManagementDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        context.Services.AddTransient<IDataSeedContributor, CategorySeedingService>();
        context.Services.AddTransient<IDataSeedContributor, DepartmentSeedingService>();
        context.Services.AddTransient<IDataSeedContributor, ProjectSeedingService>();
        context.Services.AddTransient<IDataSeedContributor, DepartmentInternalRolesSeedingService>();
        context.Services.AddTransient<IDataSeedContributor, SkillSeedingService>();
        context.Services.AddTransient<IDataSeedContributor, ProficiencySeedingService>();
        context.Services.AddTransient<IDataSeedContributor, RoleSeedingService>();
        context.Services.AddTransient<IDataSeedContributor, PermissionSeedingService>();
        context.Services.AddTransient<IDataSeedContributor, SkillSubtopicSeedingService>();
        context.Services.AddTransient<IDataSeedContributor,AbpRoleSeedingService>();
        context.Services.AddTransient<IDataSeedContributor, RolePermissionSeeder>();
        context.Services.AddTransient<IDataSeedContributor, RoleDepartmentSeedingService>();
        context.Services.AddTransient<IDataSeedContributor, DepartmentSkillSeedingService>();


        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            options.Languages.Add(new LanguageInfo("sv", "sv", "Svenska"));
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SkillMatrixManagementDomainModule>("SkillMatrixManagement");
        });

        Configure<AbpTextTemplatingOptions>(options =>
        {
            options.DefaultRenderingEngine = "Razor";
        });

    

#if DEBUG
        // Comment out this line to enable real email sending in development mode
        // context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
