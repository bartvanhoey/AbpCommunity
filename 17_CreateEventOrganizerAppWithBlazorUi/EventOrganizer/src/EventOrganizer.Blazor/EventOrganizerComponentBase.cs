using EventOrganizer.Localization;
using Volo.Abp.AspNetCore.Components;

namespace EventOrganizer.Blazor;

public abstract class EventOrganizerComponentBase : AbpComponentBase
{
    protected EventOrganizerComponentBase()
    {
        LocalizationResource = typeof(EventOrganizerResource);
    }
}
