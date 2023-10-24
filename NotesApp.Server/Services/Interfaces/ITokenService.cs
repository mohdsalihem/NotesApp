using NotesApp.Server.Dtos;
using NotesApp.Server.Models;
using System.IdentityModel.Tokens.Jwt;

namespace NotesApp.Server.Services.Interfaces;

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
