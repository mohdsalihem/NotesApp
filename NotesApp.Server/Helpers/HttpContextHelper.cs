using NotesApp.Server.Helpers.Interfaces;

namespace NotesApp.Server.Helpers;

public class HttpContextHelper : IHttpContextHelper
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public HttpContextHelper(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public int UserId
    {
        get
        {
            if (httpContextAccessor.HttpContext is null || httpContextAccessor.HttpContext.Items["userId"] is null)
                throw new UnauthorizedAccessException();

            return Convert.ToInt32(httpContextAccessor.HttpContext.Items["userId"]);
        }
    }

    public string RefreshTokenCookie { get => httpContextAccessor?.HttpContext?.Request.Cookies["refreshToken"] ?? string.Empty; }

    public void SetRefreshTokenCookie(string refreshToken, DateTime expiryDate)
    {
        httpContextAccessor?.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken, new() { HttpOnly = true, Expires = expiryDate, SameSite = SameSiteMode.None, Secure = true });
    }
}
