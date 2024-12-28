
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebTp7.Middleware
{
    public class JwtSessionMiddleware
    {
        private readonly RequestDelegate _next;
       

        public JwtSessionMiddleware(RequestDelegate next)        {
            _next = next;
           
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check if there's a JWT token in the session
            var token = context.Session.GetString("BearerToken");

            if (!string.IsNullOrEmpty(token))
            {
                // Manually set the Authorization header
                context.Request.Headers["Authorization"] = $"Bearer {token}";
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }



    
}