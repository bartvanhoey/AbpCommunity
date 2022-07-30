using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EventOrganizer.Blazor;

[Dependency(ReplaceServices = true)]
public class EventOrganizerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EventOrganizer";
}
