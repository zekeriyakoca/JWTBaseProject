using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseJWT.Domain.DTO.Account
{
    public class NewPasswordDto
    {
        public string Email { get; set; }

        public string VerificationCode { get; set; }

        public string NewPassword { get; set; }
    }
}
