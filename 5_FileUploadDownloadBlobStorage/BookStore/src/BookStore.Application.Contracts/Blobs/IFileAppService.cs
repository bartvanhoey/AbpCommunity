using System;
using System.Threading.Tasks;
using BookStore.Application.Contracts.Blobs.Dtos;

namespace BookStore.Application.Contracts.Blobs
{
    public interface IFileAppService
    {

        Task SaveBlobAsync(SaveBlobInputDto input);

        Task<BlobDto> GetBlobAsync(GetBlobRequestDto input);
    }
}
