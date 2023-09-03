using ServerApp.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ServerApp.Helpers.Interfaces;

public interface IJwtUtility
{
    string GenerateToken(User user);
    JwtSecurityToken? ValidateToken(string? tokenString);
}
