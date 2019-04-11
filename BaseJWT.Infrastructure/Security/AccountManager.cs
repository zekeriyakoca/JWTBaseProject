using BaseJWT.Domain.Entity;
using BaseJWT.Infrastructure.EntityFramework.Context;
using BaseJWT.Util.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Infrastructure.Security
{
    public class AccountManager : UserManager<User>
    {
        readonly DataContext context;
        readonly IPasswordValidator<User> passwordValidator;

        public AccountManager(IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<User>> logger,
            DataContext context) : base(store, optionsAccessor, passwordHasher, userValidators,
            passwordValidators, keyNormalizer, errors, services, logger)
        {
            passwordValidator = passwordValidators.FirstOrDefault();
            this.context = context;

            // Password settings
            Options.Password.RequireDigit = true;
            Options.Password.RequiredLength = 8;
            Options.Password.RequireNonAlphanumeric = true;
            Options.Password.RequireUppercase = true;
            Options.Password.RequireLowercase = false;
            Options.Password.RequiredUniqueChars = 4;

            // Lockout settings
            Options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            Options.Lockout.MaxFailedAccessAttempts = 100;
            Options.Lockout.AllowedForNewUsers = true;

            // User settings
            Options.User.RequireUniqueEmail = true;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {

            return await context.Users.Where(u=>u.Email == email).FirstOrDefaultAsync();
        }

        public override async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            if (user == null) throw new AppException("There is no Email");

            var confirmationResult = await base.ConfirmEmailAsync(user, token);

            if (confirmationResult != IdentityResult.Success)
                throw new SecurityException("Unable to confirm Email." +
                                          confirmationResult.Errors?.Single().Description);
            user.EmailConfirmed = true;
            return IdentityResult.Success;
        }

        public async Task ValidatePassword(User user, string password)
        {
            var passResult = await passwordValidator.ValidateAsync(this, user, password);

            if (!passResult.Succeeded)
                throw new SecurityException("Invalid password: " + passResult.Errors.FirstOrDefault()?.Description);
        }

        public async Task<User> GetUserById(string userId)
        {
            return await (from user in context.Users
                          where user.Id == userId
                          select user).FirstOrDefaultAsync();
        }

       
    }
}
