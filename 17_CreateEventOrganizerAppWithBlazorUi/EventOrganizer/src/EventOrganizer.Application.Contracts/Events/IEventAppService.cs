using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventOrganizer.Application.Contracts.Events.Dtos;
using Volo.Abp.Application.Services;

namespace EventOrganizer.Application.Contracts.Events
{
    public interface IEventAppService : IApplicationService
    {
        Task<Guid> CreateAsync(CreateEventDto input);

        Task<List<EventDto>> GetUpcomingAsync();

        Task<EventDetailDto> GetAsync(Guid id);

        Task RegisterAsync(Guid id);
        Task UnregisterAsync(Guid id);

        Task DeleteAsync(Guid id);





    }


}
