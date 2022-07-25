using System;

namespace BookStore.Application.Contracts.Blobs.Dtos
{
    public class BlobDto
    {
        public byte[] Content { get; set; }
        public string Name { get; set; }
    }
}
