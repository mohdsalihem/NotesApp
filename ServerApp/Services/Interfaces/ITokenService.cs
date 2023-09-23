using ServerApp.Dtos;
using ServerApp.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ServerApp.Services.Interfaces;

public interface ITokenService
{
    Task<string> GenerateRefreshToken();
    string GenerateAccessToken(User user);
    JwtSecurityToken? ValidateAccessToken(string? token);
    DateTime RefreshTokenExpiryDate { get; }
    Task<LoginResponseDto> Refresh();
    Task<int> Revoke();
    Task<int> RevokeAll();
}
