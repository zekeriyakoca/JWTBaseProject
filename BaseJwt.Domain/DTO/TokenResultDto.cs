using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWT.Domain.DTO
{
    public class TokenResultDto
    {
        public string Token { get; set; }

        public string TokenRecovery { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
