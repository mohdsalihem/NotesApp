using System.IdentityModel.Tokens.Jwt;
using ServerApp.Helpers.Interfaces;

namespace ServerApp.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate next;
    private readonly IJwtUtility jwtUtility;

    public JwtMiddleware(RequestDelegate next, IJwtUtility jwtUtility)
    {
        this.next = next;
        this.jwtUtility = jwtUtility;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        JwtSecurityToken? jwtSecurityToken = jwtUtility.ValidateToken(token);

        if (jwtSecurityToken != null)
            context.Items["userId"] = Convert.ToInt32(jwtSecurityToken.Claims.First(x => x.Type == "userId").Value);

        await next(context);
    }
}