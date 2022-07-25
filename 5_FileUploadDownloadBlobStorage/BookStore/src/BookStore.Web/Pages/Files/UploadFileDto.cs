using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookStore.Web.Pages.Files;

public class UploadFileDto
{

    [Required] 
    [Display(Name = "File ")] 
    
    public IFormFile File { get; set; }
    
    [Required] 
    [Display(Name = "Name ")] 
    public string Name { get; set; }

}