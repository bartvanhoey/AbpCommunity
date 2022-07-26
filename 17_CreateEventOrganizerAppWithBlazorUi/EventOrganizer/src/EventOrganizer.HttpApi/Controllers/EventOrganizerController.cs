﻿using EventOrganizer.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EventOrganizer.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EventOrganizerController : AbpControllerBase
{
    protected EventOrganizerController()
    {
        LocalizationResource = typeof(EventOrganizerResource);
    }
}
