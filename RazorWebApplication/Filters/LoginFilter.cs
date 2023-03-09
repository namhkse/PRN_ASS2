using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RazorWebApplication.Filters;

public class LoginFilter : Attribute, IPageFilter
{
    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
        var logged = context.HttpContext.Session.GetInt32("logged") != null;
        if(!logged)
        {
            context.HttpContext.Response.Redirect("/Error401");
        }
    }
}