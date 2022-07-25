using System;
using System.Threading.Tasks;
using BookStore.Application.Contracts.Blobs;
using BookStore.Application.Contracts.Blobs.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace BookStore.HttpApi.Controllers
{
    public class FileController : AbpController
    {
        private readonly IFileAppService _fileAppService;

        public FileController(IFileAppService FileAppService) => _fileAppService = FileAppService;

        [HttpGet]
        [Route("download/{fileName}")]
        public async Task<IActionResult> DownloadAsync(string fileName)
        {
            var fileDto = await _fileAppService.GetBlobAsync(new GetBlobRequestDto {Name = fileName});
            return File(fileDto.Content, "application/octet-stream", fileDto.Name);
        }



    }
}
