using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomSignInManager.HttpApi.Host
{
    public class MyCustomSignInManager : Microsoft.AspNetCore.Identity.SignInManager<Volo.Abp.Identity.IdentityUser>
    {

        private const string LoginProviderKey = "LoginProvider";
        private const string XsrfKey = "XsrfId";


        public MyCustomSignInManager(
            UserManager<Volo.Abp.Identity.IdentityUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<Volo.Abp.Identity.IdentityUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<Volo.Abp.Identity.IdentityUser>> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<Volo.Abp.Identity.IdentityUser> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }

        public override async Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null)
        {
            var auth = await Context.AuthenticateAsync(Microsoft.AspNetCore.Identity.IdentityConstants.ExternalScheme);
            var items = auth?.Properties?.Items;

            if (auth?.Principal == null || items == null || !items.ContainsKey(LoginProviderKey))
                return null;


            if (expectedXsrf != null)
            {
                if (!items.ContainsKey(XsrfKey)) return null;

                var userId = items[XsrfKey] as string;
                if(userId != expectedXsrf) return null;
            }

            var providerKey = auth.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var provider = items[LoginProviderKey] as string;

            if (providerKey == null || provider == null ) return null;

            var providerDisplayName = (await GetExternalAuthenticationSchemesAsync()).FirstOrDefault(p => p.Name == provider)?.DisplayName ?? provider;

            return new ExternalLoginInfo(auth.Principal, provider, providerKey, providerDisplayName)
            {
                AuthenticationTokens = auth.Properties.GetTokens(), 
                AuthenticationProperties = auth.Properties
            };


        }
    }
}
