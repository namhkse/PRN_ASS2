using Microsoft.AspNetCore.Mvc;
using ShopWebApplication.Models;

namespace ShopWebApplication.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
