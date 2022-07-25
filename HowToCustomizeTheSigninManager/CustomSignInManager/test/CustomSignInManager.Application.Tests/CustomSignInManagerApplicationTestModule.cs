using Volo.Abp.Modularity;

namespace CustomSignInManager;

[DependsOn(
    typeof(CustomSignInManagerApplicationModule),
    typeof(CustomSignInManagerDomainTestModule)
    )]
public class CustomSignInManagerApplicationTestModule : AbpModule
{

}
