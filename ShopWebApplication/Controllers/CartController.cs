using Microsoft.AspNetCore.Mvc;

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
