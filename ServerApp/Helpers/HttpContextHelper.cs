using ServerApp.Helpers.Interfaces;

namespace ServerApp.Helpers;

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
}
