using System.IdentityModel.Tokens.Jwt;
using NotesApp.Server.Services.Interfaces;

namespace NotesApp.Server.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate next;
    private readonly ITokenService tokenService;

    public JwtMiddleware(RequestDelegate next, ITokenService tokenService)
    {
        this.next = next;
        this.tokenService = tokenService;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        JwtSecurityToken? jwtSecurityToken = tokenService.ValidateAccessToken(token);

        if (jwtSecurityToken != null)
            context.Items["userId"] = Convert.ToInt32(jwtSecurityToken.Claims.First(x => x.Type == "userId").Value);

        await next(context);
    }
}