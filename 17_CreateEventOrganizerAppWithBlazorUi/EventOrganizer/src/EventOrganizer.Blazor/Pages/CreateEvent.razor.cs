using System;
using System.Threading.Tasks;
using EventOrganizer.Application.Contracts.Events;
using EventOrganizer.Application.Contracts.Events.Dtos;
using Microsoft.AspNetCore.Components;

namespace EventOrganizer.Blazor.Pages
{
    public partial class CreateEvent
    {
        private  IEventAppService _eventAppService;
        private  NavigationManager _navigationManager;

        private CreateEventDto Event { get; set; } = new CreateEventDto();

        public CreateEvent(IEventAppService eventAppService, NavigationManager navigationManager)
        {
            _eventAppService = eventAppService;
            _navigationManager = navigationManager;
        }

        public async Task Create()
        {
            var eventId = await _eventAppService.CreateAsync(Event);
            _navigationManager.NavigateTo($"/events/{eventId}");

        }
    }
}
