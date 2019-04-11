using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseJWT.API.Middleware
{
    public class AuthorizationPatchMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationPatchMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
    }

    public static class AuthorizationPatchMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthorizationPatch(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationPatchMiddleware>();
        }
    }
}
