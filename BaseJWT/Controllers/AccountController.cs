using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseJWT.Domain.DTO.Account;
using BaseJWT.Domain.Entity;
using BaseJWT.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseJWT.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IJwToken tokenService;

        public AccountController(UserManager<User> userManager, IJwToken tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, dto.Password))
            {
                return Unauthorized();
            }
            var tokenResult = tokenService.GetToken(user.Id, user.Email);
            return Ok(tokenResult);
        }

        [HttpGet("test")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Test()
        {

            return Ok("Success");
        }
    }
}
