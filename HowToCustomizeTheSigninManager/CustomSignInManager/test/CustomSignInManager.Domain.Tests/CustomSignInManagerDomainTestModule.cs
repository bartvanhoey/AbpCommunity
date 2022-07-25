using CustomSignInManager.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CustomSignInManager;

[DependsOn(
    typeof(CustomSignInManagerEntityFrameworkCoreTestModule)
    )]
public class CustomSignInManagerDomainTestModule : AbpModule
{

}
