using System;
using System.Linq;
using System.Threading.Tasks;
using EventOrganizer.Application.Contracts.Events;
using EventOrganizer.Application.Contracts.Events.Dtos;
using Microsoft.AspNetCore.Components;

namespace EventOrganizer.Blazor.Pages
{
    public partial class EventDetail
    {
        private IEventAppService _eventAppService;
        private NavigationManager _navigationManager;

        [Parameter] public string Id { get; set; }

        private EventDetailDto Event { get; set; }
        private bool IsRegistered { get; set; }


        public EventDetail(IEventAppService eventAppService, NavigationManager navigationManager)
        {
            _eventAppService = eventAppService;
            _navigationManager = navigationManager;
        }


        protected override async Task OnInitializedAsync()
        {
            await GetEventsAsync();
        }

        private async Task GetEventsAsync()
        {
            Event = await _eventAppService.GetAsync(Guid.Parse(Id));

            if (CurrentUser.IsAuthenticated)
            {
                IsRegistered = Event.Attendees.Any(attendee => attendee.UserId == CurrentUser.Id);
            }
        }

        private async Task Register()
        {
            await _eventAppService.RegisterAsync(Guid.Parse(Id));
            await GetEventsAsync();
        }

        private async Task UnRegister()
        {
            await _eventAppService.UnregisterAsync(Guid.Parse(Id));
            await GetEventsAsync();
        }

        private async Task Delete()
        {
            if (!await Message.Confirm("This event will be deleted: " + Event.Title))
            {
                return;
            }

            await _eventAppService.DeleteAsync(Guid.Parse(Id));
            _navigationManager.NavigateTo("/");
        }

    }
}
