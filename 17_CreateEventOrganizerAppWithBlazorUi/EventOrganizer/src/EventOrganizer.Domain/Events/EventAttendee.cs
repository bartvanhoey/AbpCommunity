using System;
using Volo.Abp.Auditing;

namespace EventOrganizer.Domain.Events
{
    public class EventAttendee : IHasCreationTime
    {
        public Guid UserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
