using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Contracts.Blobs.Dtos
{
    public class SaveBlobInputDto
    {
        public byte[] Content { get; set; }

        [Required] 
        public string Name { get; set; }
    }
}
