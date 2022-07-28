using TemplateReplace.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TemplateReplace.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TemplateReplaceController : AbpControllerBase
{
    protected TemplateReplaceController()
    {
        LocalizationResource = typeof(TemplateReplaceResource);
    }
}
