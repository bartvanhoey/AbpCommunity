using System;
using System.IO;
using System.Threading.Tasks;
using BookStore.Application.Contracts.Blobs;
using BookStore.Application.Contracts.Blobs.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BookStore.Web.Pages.Files
{
    public class Index : AbpPageModel
    {
        private readonly IFileAppService _fileAppService;

        [BindProperty]
        public UploadFileDto UploadFileDto { get; set; }
        public bool Uploaded { get; set; } = false;

        public Index(IFileAppService fileAppService) => _fileAppService = fileAppService;


        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await UploadFileDto.File.CopyToAsync(memoryStream);

                await _fileAppService.SaveBlobAsync(new SaveBlobInputDto{ Name = UploadFileDto.Name, Content = memoryStream.ToArray()});

            }
            return Page();
        }


    }
}
