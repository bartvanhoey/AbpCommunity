using System;
using System.Collections.Generic;
using System.Text;
using CustomSignInManager.Localization;
using Volo.Abp.Application.Services;

namespace CustomSignInManager;

/* Inherit your application services from this class.
 */
public abstract class CustomSignInManagerAppService : ApplicationService
{
    protected CustomSignInManagerAppService()
    {
        LocalizationResource = typeof(CustomSignInManagerResource);
    }
}
