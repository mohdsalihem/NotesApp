using System.Net;
using System.Text.Json;
using System.Collections;

namespace NotesApp.Server.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ErrorHandlerMiddleware> logger;

    public ErrorHandlerMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlerMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context, IHostEnvironment env)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex, env);
        }
    }

    private Task HandleException(HttpContext context, Exception exception, IHostEnvironment env)
    {
        logger.LogError(exception.ToString());

        IDictionary data = exception.Data;
        string message = exception is AggregateException aggregateException ? aggregateException.Flatten().Message : exception.Message;
        string result = JsonSerializer.Serialize(new
        {
            message,
            data
        });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

        return context.Response.WriteAsync(result);
    }
}
