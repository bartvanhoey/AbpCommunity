using CustomSignInManager.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CustomSignInManager.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CustomSignInManagerEntityFrameworkCoreModule),
    typeof(CustomSignInManagerApplicationContractsModule)
    )]
public class CustomSignInManagerDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
