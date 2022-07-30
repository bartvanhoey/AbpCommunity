using System;
using System.ComponentModel.DataAnnotations;

namespace EventOrganizer.Application.Contracts.Events.Dtos
{
    public class CreateEventDto
    {

        [Required]
        [StringLength(100)] 
        public string Title { get; set; }

        [Required]
        [StringLength(100)] 
        public string Description { get; set; }
        public bool IsFree { get; set; }

        public DateTime StartTime { get; set; }
    }
}
