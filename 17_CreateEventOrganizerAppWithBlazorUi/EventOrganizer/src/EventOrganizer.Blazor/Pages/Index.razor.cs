using System.Collections.Generic;
using System.Threading.Tasks;
using EventOrganizer.Application.Contracts.Events;
using EventOrganizer.Application.Contracts.Events.Dtos;

namespace EventOrganizer.Blazor.Pages;

public partial class Index
{
    private readonly IEventAppService _eventAppService;

    private List<EventDto> UpcomingEvents { get; set; } = new List<EventDto>();

    public Index(IEventAppService eventAppService) => _eventAppService = eventAppService;

    protected override async Task OnInitializedAsync()
    {
        UpcomingEvents = await _eventAppService.GetUpcomingAsync();
    }
}
