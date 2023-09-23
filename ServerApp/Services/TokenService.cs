using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServerApp.AppSettings;
using ServerApp.Dtos;
using ServerApp.Helpers.Interfaces;
using ServerApp.Models;
using ServerApp.Repositories.Interfaces;
using ServerApp.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ServerApp.Services;

public class TokenService : ITokenService
{
    private readonly IHttpContextHelper httpContextHelper;
    private readonly IRefreshTokenRepository refreshTokenRepository;
    private readonly IUserRepository userRepository;
    private readonly JwtCredentials jwtCredentials;

    public TokenService( 
        IHttpContextHelper httpContextHelper, 
        IRefreshTokenRepository refreshTokenRepository,
        IOptions<JwtCredentials> jwtCredentials,
        IUserRepository userRepository)
    {
        this.httpContextHelper = httpContextHelper;
        this.refreshTokenRepository = refreshTokenRepository;
        this.userRepository = userRepository;
        this.jwtCredentials = jwtCredentials.Value;
    }

    public DateTime GetRefreshTokenExpiryDate() => DateTime.UtcNow.AddSeconds(10);

    public string GenerateAccessToken(User user)
    {
        // Generate token that is valid for 2 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtCredentials.JwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[] { new Claim("userId", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddSeconds(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public JwtSecurityToken? ValidateAccessToken(string? token)
    {
        if (token is null)
            return null;

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtCredentials.JwtSecret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                // Set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
        catch
        {
            return null;
        }
    }

    public async Task<string> GenerateRefreshToken()
    {
        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        // Ensure token is unique by checking against db
        bool isTokenExist = await refreshTokenRepository.IsTokenExist(refreshToken);
        if (isTokenExist)
            await GenerateRefreshToken();

        return refreshToken;
    }

    public async Task<LoginResponseDto> Refresh()
    {

        RefreshToken refreshToken = await refreshTokenRepository.Get(httpContextHelper.GetRefreshTokenCookie()) ?? throw new Exception("Token does not exist");

        if (refreshToken.ExpiryDate < DateTime.UtcNow)
            throw new Exception("Token expired");

        User user = await userRepository.Get(refreshToken.UserId);
        string accessToken = GenerateAccessToken(user);
        refreshToken.Token = await GenerateRefreshToken();
        refreshToken.ExpiryDate = GetRefreshTokenExpiryDate();
        await refreshTokenRepository.Update(refreshToken);

        httpContextHelper.SetRefreshTokenCookie(refreshToken.Token, refreshToken.ExpiryDate);

        return new LoginResponseDto()
        {
            Username = user.Username,
            Token = accessToken
        };
    }

    public async Task<int> Revoke()
    {
        RefreshToken token = await refreshTokenRepository.Get(httpContextHelper.GetRefreshTokenCookie()) ?? throw new Exception("Token does not exist");
        return await refreshTokenRepository.Delete(token.Id);
    }

    public async Task<int> RevokeAll()
    {
        RefreshToken token = await refreshTokenRepository.Get(httpContextHelper.GetRefreshTokenCookie()) ?? throw new Exception("Token does not exist");
        return await refreshTokenRepository.DeleteByUserId(token.UserId);
    }
}
