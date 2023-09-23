namespace ServerApp.Helpers.Interfaces;

public interface IHttpContextHelper
{
    int UserId { get; }
    string RefreshTokenCookie { get; }
    void SetRefreshTokenCookie(string refreshToken, DateTime expiryDate);
}
