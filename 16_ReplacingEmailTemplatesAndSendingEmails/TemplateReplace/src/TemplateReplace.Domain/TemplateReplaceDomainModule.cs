using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TemplateReplace.MultiTenancy;
using Volo.Abp;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace TemplateReplace;

[DependsOn(
    typeof(TemplateReplaceDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpIdentityServerDomainModule),
    typeof(AbpPermissionManagementDomainIdentityServerModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpTenantManagementDomainModule),
    typeof(AbpEmailingModule)
)]
public class TemplateReplaceDomainModule : AbpModule
{

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var settingManager = context.ServiceProvider.GetService<SettingManager>();//encrypts the password on set and decrypts on get
        settingManager.SetGlobalAsync(EmailSettingNames.Smtp.Password, "google-generated-password-here");
    }


    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        // #if DEBUG
        //         // context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
        // #endif

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
             options.FileSets.AddEmbedded<TemplateReplaceDomainModule>();
        });

    }
}
