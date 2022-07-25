using System;
using System.Threading.Tasks;
using BookStore.Application.Contracts.Blobs;
using BookStore.Application.Contracts.Blobs.Dtos;
using BookStore.Domain.Blobs;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace BookStore.Application.Blobs
{
    public class FileAppService : ApplicationService, IFileAppService
    {
        private readonly IBlobContainer<MyFileContainer> _myFileContainer;

        public FileAppService(IBlobContainer<MyFileContainer> myFileContainer) => _myFileContainer = myFileContainer;

        public async Task<BlobDto> GetBlobAsync(GetBlobRequestDto input)
        {
            var blob = await _myFileContainer.GetAllBytesAsync(input.Name);
            
            return new BlobDto
            {
                Name = input.Name,
                Content = blob
            };
        }

        public async Task SaveBlobAsync(SaveBlobInputDto input)
        {
            await _myFileContainer.SaveAsync(input.Name, input.Content, true); 
        }
    }
}
