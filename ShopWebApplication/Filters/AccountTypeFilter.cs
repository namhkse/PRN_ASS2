using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShopWebApplication.Filters
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	public class AccountTypeFilter : Attribute, IActionFilter
	{
		private readonly int[] _types;

		public AccountTypeFilter(params int[] types)
		{
			_types = types;
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			var session = context.HttpContext.Session;
			int type = session.GetInt32("type") ?? -1;

			if(!_types.Contains(type))
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}
