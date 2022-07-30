using AutoMapper;
using EventOrganizer.Application.Contracts.Events.Dtos;
using EventOrganizer.Domain.Events;

namespace EventOrganizer;

public class EventOrganizerApplicationAutoMapperProfile : Profile
{
    public EventOrganizerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

         CreateMap<CreateEventDto, Event>();
         CreateMap<Event, EventDto>();
         CreateMap<Event,EventDetailDto>();
         CreateMap<EventAttendee, EventAttendeeDto>();
    }
}
