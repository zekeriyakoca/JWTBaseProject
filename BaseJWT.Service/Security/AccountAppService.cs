using BaseJWT.Domain.DTO.Account;
using BaseJWT.Domain.Entity;
using BaseJWT.Domain.Interface;
using BaseJWT.Infrastructure.Security;
using BaseJWT.Infrastructure.Security.Events;
using BaseJWT.Infrastructure.Security.Validation;
using BaseJWT.Service.Interface;
using BaseJWT.Util.Domain;
using BaseJWT.Util.Infrastructure;
using BaseJWT.Util.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Service.Security
{
    public class AccountAppService : IAccountAppService
    {
        readonly AccountManager accountManager;
        private readonly IAssertion assertion;
        readonly AccountSignIn accountSign;
        //readonly IEmailPasswordRecovered emailPasswordRecovered;
        //readonly IEmailTemporaryPassword emailTemporaryCode;
        readonly IUnitOfWork work;
        //readonly IEmailUserConfirmation emailUserConfirmation;
        readonly ILogger<AccountAppService> logger;

        public AccountAppService(IUnitOfWork work,
            AccountManager accountManager,
            IAssertion assertion,
            AccountSignIn accountSign,
            ILogger<AccountAppService> logger)
        {
            this.logger = logger;
            this.accountSign = accountSign;
            this.accountManager = accountManager;
            this.work = work;
            this.assertion = assertion;
        }

        //public async Task Registrar(UserTypeEnum userType, string firstName, string lastName, string email, string password)
        //{
        //    await assertion.Check<UserRegistrationAssertion, UserRegistrationAssertionArgs>(
        //        new UserRegistrationAssertionArgs
        //        {
        //           Email = email,
        //           Password = password
        //        });

        //    StoreUser user = await accountManager.GetUserByEmailAsync(email);
        //    if (user != null)
        //    {
        //        throw new BusinessException("There is already an account with this Email. Please try again.");
        //    }

        //    user = new StoreUser(email);

        //    if (accountManager.SupportsUserSecurityStamp) user.SecurityStamp = Guid.NewGuid().ToString();

        //    user.IsEnabled = false; 
        //    user.PasswordHash = accountManager.PasswordHasher.HashPassword(user, password);

        //    var result = await accountManager.CreateAsync(user, password);

        //    if (!result.Succeeded) throw new Exception(result.Errors.FirstOrDefault()?.Description);

        //    var token = await accountManager.GenerateEmailConfirmationTokenAsync(user);

        //    await DomainEvents.Raise(new UserRegisterEvent(UserTypeEnum.Customer, email, token));

        //    logger.LogInformation($"Registiration complated - Email {user.Email}");

        //    await work.Complete();
        //}

        //public async Task<LoginResponseDto> Login(string email, string password)
        //{
        //    var user = await accountManager.GetUserByEmailAsync(email);
        //    if (user == null)
        //    {
        //        throw new BusinessException("There is no user with this Email");
        //    }
        //    if (!await accountSign.CanSignInAsync(user))
        //        return null;
        //    var signResult = await accountSign.CheckPasswordSignInAsync(user, password, false);

        //    return new LoginResponseDto
        //    {
        //        UserId = user.Id,
        //        Email = user.Email
        //    };
        //}

        //public async Task ResetPassword(string email)
        //{
        //    var Usuario = await accountManager.GetUserByEmailAsync(email);

        //    if (Usuario == null) throw new BusinessException("There is no user with this Email.");

        //    if (!Usuario.EmailConfirmed)
        //    {
        //        throw new BusinessException("Email not verified.");
        //    }
        //    else
        //    {
        //        var code = await new EmailTokenProvider<StoreUser>().GenerateAsync("password_recovery", accountManager, Usuario);

        //        //emailTemporaryCode.Send(Usuario.Email, code);
        //    }

        //    logger.LogInformation($"Reset password requested by Email {email}");
        //}

        //public async Task<bool> UpdatePassword(string email, string code, string password)
        //{
        //    var User = await accountManager.GetUserByEmailAsync(email);

        //    if (User == null) throw new BusinessException("There is no user with this Email.");

        //    var isOtpValid =
        //        await new EmailTokenProvider<StoreUser>().ValidateAsync("password_recovery", code, accountManager, User);

        //    if (isOtpValid)
        //    {
        //        var isPasswordValid =
        //            await accountManager.PasswordValidators[0].ValidateAsync(accountManager, User, password);
        //        if (isPasswordValid == IdentityResult.Success)
        //            User.PasswordHash = accountManager.PasswordHasher.HashPassword(User, password);
        //        else
        //            throw new BusinessException(isPasswordValid.ToString());
        //    }
        //    else
        //    {
        //        throw new BusinessException("Temporal code is invalid.");
        //    }

        //    await work.Complete();

        //    //Task.Run(() => emailPasswordRecovered.Send(User.Email));

        //    logger.LogInformation($"Password updated by Email {email}");

        //    return isOtpValid;
        //}

        //public async Task UpdateEmail(string newEmail)
        //{
        //    var user = await accountManager.GetUserByEmailAsync(newEmail);

        //    if (user.Email != newEmail)
        //    {
        //        var newEmailUser = await accountManager.FindByEmailAsync(newEmail);
        //        if (newEmailUser != null)
        //        {
        //            throw new BusinessException("Email is already in use");
        //        }
        //        else
        //        {
        //            logger.LogInformation($"Email updated from {user.Email} to {newEmail}");

        //            user.Email = newEmail;
        //            user.UserName = newEmail;
        //            user.EmailConfirmed = false;

        //            await accountManager.UpdateAsync(user);
        //            await work.Complete();
        //        }
        //    }

        //    var token = await accountManager.GenerateEmailConfirmationTokenAsync(user);
        //   // emailUserConfirmation.Send(newEmail, token);
        //}
    }
}
