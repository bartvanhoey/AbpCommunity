using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Contracts.Blobs.Dtos
{
    public class GetBlobRequestDto
    {
        [Required] 
        public string Name { get; set; }
    }
}
