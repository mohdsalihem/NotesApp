namespace ServerApp.Helpers.Interfaces;

public interface IHttpContextHelper
{
    int UserId { get; }
    string GetRefreshTokenCookie();
    void SetRefreshTokenCookie(string refreshToken, DateTime expiryDate);
}
