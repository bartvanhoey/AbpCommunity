using CustomSignInManager.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CustomSignInManager.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CustomSignInManagerController : AbpControllerBase
{
    protected CustomSignInManagerController()
    {
        LocalizationResource = typeof(CustomSignInManagerResource);
    }
}
