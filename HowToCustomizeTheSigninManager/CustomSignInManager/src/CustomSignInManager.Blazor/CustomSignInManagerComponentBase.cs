using CustomSignInManager.Localization;
using Volo.Abp.AspNetCore.Components;

namespace CustomSignInManager.Blazor;

public abstract class CustomSignInManagerComponentBase : AbpComponentBase
{
    protected CustomSignInManagerComponentBase()
    {
        LocalizationResource = typeof(CustomSignInManagerResource);
    }
}
