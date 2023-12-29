using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using UserIdentityDemo.Areas.Identity.Data;

namespace UserIdentityDemo
{
    public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<SampleUserData>
    {
        public AppUserClaimsPrincipalFactory(UserManager<SampleUserData> userManager, IOptions<IdentityOptions> options) 
            : base(userManager, options)
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(SampleUserData user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FullName", user.fullName));
            return identity;
        }
    }
}
