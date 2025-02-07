using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace PersonDirectory.API.MiddleWare;

public class CultureMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        await _next.Invoke(context);
    }
}

public static class CultureExtensions
{
    public static IApplicationBuilder UseCulture(this IApplicationBuilder builder)
    {
      
        var supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("ka-GE")
        };
        builder.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("ka-GE"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });
        return builder.UseMiddleware<CultureMiddleware>();
    }
}
