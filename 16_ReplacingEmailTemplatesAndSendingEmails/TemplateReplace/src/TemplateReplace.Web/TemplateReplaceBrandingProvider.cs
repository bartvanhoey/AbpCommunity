using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TemplateReplace.Web;

[Dependency(ReplaceServices = true)]
public class TemplateReplaceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TemplateReplace";
}
