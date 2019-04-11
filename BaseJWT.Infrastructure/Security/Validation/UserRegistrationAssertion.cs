using BaseJWT.Infrastructure.EntityFramework.Context;
using BaseJWT.Util.Infrastructure;
using BaseJWT.Util.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Infrastructure.Security.Validation
{
    public class UserRegistrationAssertion : IAssertionHandler<UserRegistrationAssertionArgs>
    {
        readonly AccountManager accountManager;
        readonly DataContext context;

        public UserRegistrationAssertion(DataContext context, AccountManager accountManager)
        {
            this.accountManager = accountManager;
            this.context = context;
        }
        public async Task Check(UserRegistrationAssertionArgs param)
        {
            if (param.Email != null) throw new AppException("Email cannot be null");

            await Task.FromResult(0);
        }
    }
}
