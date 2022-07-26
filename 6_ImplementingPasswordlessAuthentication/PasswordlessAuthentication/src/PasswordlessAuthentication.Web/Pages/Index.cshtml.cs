// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Volo.Abp.Identity;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Identity;

namespace PasswordlessAuthentication.Web.Pages;

public class IndexModel : PasswordlessAuthenticationPageModel
{
    private readonly IdentityUserManager UserManager;
    private readonly IIdentityUserRepository _userRepository;

    public string PasswordlessLoginUrl { get; set; }
    public string Email { get; set; }

    public IndexModel(IdentityUserManager identityUserManager, IIdentityUserRepository identityUserRepository)
    {
        UserManager = identityUserManager;
        _userRepository = identityUserRepository;
    }

    public ActionResult OnGet()
    {
        if (!CurrentUser.IsAuthenticated)
        {
            return Redirect("/Account/Login");
        }
        return Page();
    }

    public async Task<IActionResult> OnPostGeneratePasswordlessTokenAsync()
    {
        var adminUser = await _userRepository.FindByNormalizedUserNameAsync("admin");

        var token = await UserManager.GenerateUserTokenAsync(adminUser, "PasswordlessLoginProvider", "passwordless-auth");

        PasswordlessLoginUrl = Url.Action("Login", "Passwordless", new { token = token, userId = adminUser.Id.ToString() }, Request.Scheme);
        return Page();
    }


}
