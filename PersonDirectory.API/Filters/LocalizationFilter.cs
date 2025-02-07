using Microsoft.AspNetCore.Mvc.Filters;

namespace PersonDirectory.API.Filters;

public class LocalizationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
      var language =  context.HttpContext.Request.Headers.AcceptLanguage;
        if (!string.IsNullOrWhiteSpace(language)) 
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(language!);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(language!);
        }
    
    }
    public void OnActionExecuted(ActionExecutedContext context) { }
}
