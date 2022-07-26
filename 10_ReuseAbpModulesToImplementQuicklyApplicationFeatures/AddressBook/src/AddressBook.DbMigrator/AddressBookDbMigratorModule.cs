using AddressBook.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AddressBook.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AddressBookEntityFrameworkCoreModule),
        typeof(AddressBookApplicationContractsModule)
    )]
    public class AddressBookDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
