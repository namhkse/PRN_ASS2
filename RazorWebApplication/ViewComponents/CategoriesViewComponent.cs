using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using RazorWebApplication.Models;

namespace RazorWebApplication.ViewComponents
{
	public class CategoriesViewComponent : ViewComponent
	{
		private readonly PizzaStoreContext _context;

		public CategoriesViewComponent(PizzaStoreContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var categories = _context.Categories.ToList();
			return View(categories);
		}
	}
}
