using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CustomSignInManager;

[Dependency(ReplaceServices = true)]
public class CustomSignInManagerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CustomSignInManager";
}
