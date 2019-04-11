using BaseJWT.Domain.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseJWT.Infrastructure.Security
{
    public interface IJwToken
    {
        TokenResultDto GetToken(string userId,  string userEmail);
    }

    public class JwToken : IJwToken
    {
        private readonly IConfiguration configuration;

        public JwToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public TokenResultDto GetToken(string userId, string userEmail)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userEmail),
                new Claim(JwtRegisteredClaimNames.Jti, userId.ToString())
            };

            var key = configuration["Tokens:Key"];
            var issuer = configuration["Tokens:Issuer"];
            var validFor = int.Parse(configuration["Tokens:ValidFor"]);

            var expiresAt = DateTime.Now.AddDays(validFor);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer,
                issuer,
                claims,
                expires: expiresAt,
                signingCredentials: creds);

            var tokenRecovery = new JwtSecurityToken(issuer,
                issuer,
                claims,
                expires: expiresAt.AddDays(180),
                signingCredentials: creds);

            return new TokenResultDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                TokenRecovery = new JwtSecurityTokenHandler().WriteToken(tokenRecovery),
                ExpiresAt = expiresAt
            };
        }
    }
}
