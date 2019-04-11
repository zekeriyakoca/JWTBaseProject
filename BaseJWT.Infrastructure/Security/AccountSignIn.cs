using BaseJWT.Domain.Entity;
using BaseJWT.Util.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Infrastructure.Security
{
    public class AccountSignIn : SignInManager<User>
    {
        public AccountSignIn(UserManager<User> userManager, IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }

        public override async Task<SignInResult> CheckPasswordSignInAsync(User user, string password,
            bool lockoutOnFailure)
        {
            if (user == null) throw new AppException("There is no such an user");

            var result = await base.CheckPasswordSignInAsync(user, password, lockoutOnFailure);

            if (result != SignInResult.Success)
                if (result == SignInResult.LockedOut)
                    throw new SecurityException("Account locked out");
                else
                    throw new SecurityException("Incorrect password");

            return result;
        }

        public override Task<bool> CanSignInAsync(User user)
        {
            if (!user.IsEnabled)
                throw new AppException("User disabled");

            return Task.FromResult(true);
        }
    }
}
