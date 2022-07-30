using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventOrganizer.Application.Contracts.Events;
using EventOrganizer.Application.Contracts.Events.Dtos;
using EventOrganizer.Domain.Events;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace EventOrganizer.Application.Events
{
    public class EventAppService : EventOrganizerAppService, IEventAppService
    {
        private readonly IRepository<Event, Guid> _eventRepository;
        private readonly IRepository<IdentityUser, Guid> _userRepository;

        public EventAppService(IRepository<Event, Guid> eventRepository, IRepository<IdentityUser, Guid> userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateAsync(CreateEventDto input)
        {

            var eventEntity = ObjectMapper.Map<CreateEventDto, Event>(input);
            await _eventRepository.InsertAsync(eventEntity);
            return eventEntity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {

            var @event = await _eventRepository.GetAsync(id);

            if (CurrentUser.Id != @event.CreatorId)
            {
                throw new UserFriendlyException("You don't have the necessary permission to delete ...");
            }

            await _eventRepository.DeleteAsync(id);

        }

        public async Task<EventDetailDto> GetAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
            var attendeeIds = @event.Attendees.Select(a => a.UserId).ToList();


            var queryable = await _userRepository.GetQueryableAsync();
            var query = queryable.Where(u => attendeeIds.Contains(u.Id));


            var attendees = (await AsyncExecuter.ToListAsync(query)).ToDictionary(x => x.Id);

            var result = ObjectMapper.Map<Event, EventDetailDto>(@event);

            foreach (var attendeeDto in result.Attendees)
            {
                attendeeDto.UserName = attendees[attendeeDto.UserId].UserName;
            }

            return result;
        }

        public async Task<List<EventDto>> GetUpcomingAsync()
        {

            var queryable = await _eventRepository.GetQueryableAsync();
            var query = queryable
                            .Where(x => x.StartTime > Clock.Now)
                            .OrderBy(x => x.StartTime);


            var events = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<Event>, List<EventDto>>(events);




        }

        public async Task RegisterAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);

            if (@event.Attendees.Any(a => a.UserId == CurrentUser.Id))
            {
                return;
            }

            @event.Attendees.Add(new EventAttendee { UserId = CurrentUser.GetId(), CreationTime = Clock.Now });
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task UnregisterAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
            var removedItems = @event.Attendees.RemoveAll(x => x.UserId == CurrentUser.Id);
            if (removedItems.Any())
            {
                await _eventRepository.UpdateAsync(@event);
            }
        }
    }
}
