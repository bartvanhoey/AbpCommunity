using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;

namespace PasswordlessAuthentication.Web.Controllers
{
    public class PasswordlessController : AbpController
    {
        private readonly IdentityUserManager UserManager;
        private readonly AbpSignInManager _signInManager;

        public PasswordlessController(IdentityUserManager identityUserManager, AbpSignInManager signInManager)
        {
            UserManager = identityUserManager;
            _signInManager = signInManager;
        }

        public virtual async Task<IActionResult> Login(string token, string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);

            var isValid = await UserManager.VerifyUserTokenAsync(user, "PasswordlessLoginProvider", "passwordless-auth", token);

            await UserManager.UpdateSecurityStampAsync(user);
            
            await _signInManager.SignInAsync(user, false);

            return Redirect("/");
        }


    }


}
