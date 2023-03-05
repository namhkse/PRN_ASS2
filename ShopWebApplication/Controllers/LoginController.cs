
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWebApplication.Models;

namespace ShopWebApplication.Controllers
{
	public class LoginController : Controller
	{
		PizzaStoreContext _context;

		public LoginController(PizzaStoreContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(string username, string password)
		{
			var account = await _context.Accounts.FirstOrDefaultAsync(account => account.UserName.Equals(username) && account.Password.Equals(password));

			if (account == null)
			{
				ViewData["loginMessage"] = "Wrong username or password!";
				return View("Index");
			}
			else {
				var session = HttpContext.Session;
				session.SetInt32("logged", 1);
				session.SetInt32("accountId", account.AccountId);
				session.SetString("username", account.UserName);
				session.SetInt32("type", account.Type);
				return Redirect("/Products");
			}
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return Redirect("/Products");
		}
	}
}
