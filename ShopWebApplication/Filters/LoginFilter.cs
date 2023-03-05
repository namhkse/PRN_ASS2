using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShopWebApplication.Filters
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	public class LoginFilter : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			var session = context.HttpContext.Session;
			var logged = session.GetInt32("logged") == 1;

			if(!logged)
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}
