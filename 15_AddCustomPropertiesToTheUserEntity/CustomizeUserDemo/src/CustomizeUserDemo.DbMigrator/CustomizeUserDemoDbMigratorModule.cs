using CustomizeUserDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CustomizeUserDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CustomizeUserDemoEntityFrameworkCoreModule),
    typeof(CustomizeUserDemoApplicationContractsModule)
    )]
public class CustomizeUserDemoDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
