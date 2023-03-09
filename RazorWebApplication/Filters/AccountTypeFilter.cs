using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using RazorWebApplication.Models;

namespace RazorWebApplication.Filters;

[LoginFilter]
public class AccountTypeFilter : Attribute, IPageFilter
{

    public int[] _types { get; set; }

    public AccountTypeFilter(params int[] types)
    {
        _types = types; 
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
        int type = context.HttpContext.Session.GetInt32("accountType") ?? -1;
        if(!_types.Contains(type))
        {
            context.HttpContext.Response.Redirect("/Error403");
        }
    }
}