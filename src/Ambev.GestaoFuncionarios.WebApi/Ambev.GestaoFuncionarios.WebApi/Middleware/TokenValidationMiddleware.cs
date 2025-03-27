using Ambev.GestaoFuncionarios.Domain.Services.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Ambev.GestaoFuncionarios.WebApi.Middleware
{
    public class TokenValidationMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context, IServiceScopeFactory scopeFactory)
        {
            if (context.Request.Path.StartsWithSegments("/swagger") || context.Request.Path.ToString().Contains("/auth"))
            {
                await _next(context);
                return;
            }

            using var scope = scopeFactory.CreateScope();
            var _tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token não foi fornecido!");
                return;
            }

            try
            {
                bool valid = _tokenService.ValidateToken(token);
                if (!valid)
                    throw new SecurityTokenException();

                await _next(context);
            }
            catch (SecurityTokenException ex)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync($"Token inválido: {ex.Message}");
            }
        }
    }
}