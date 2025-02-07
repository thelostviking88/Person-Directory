using System.Net;
using System.Text.Json;

namespace PersonDirectory.API.MiddleWare;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
                InnerMessage = ex.InnerException?.Message
            };
            _logger.LogError(message: JsonSerializer.Serialize(response));
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }
}

