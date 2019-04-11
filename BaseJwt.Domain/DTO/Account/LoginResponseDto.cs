using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWT.Domain.DTO.Account
{
    public class LoginResponseDto
    {
        [JsonProperty("token")] public TokenResultDto Token { get; set; }

        public string UserId { get; set; }

        [JsonIgnore] public string Email { get; set; }
    }
}
