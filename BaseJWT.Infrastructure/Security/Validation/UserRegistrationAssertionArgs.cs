using BaseJWT.Util.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWT.Infrastructure.Security.Validation
{
    public class UserRegistrationAssertionArgs : IAssertionArgs
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
