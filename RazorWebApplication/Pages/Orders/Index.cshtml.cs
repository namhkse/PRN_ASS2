using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplication.Models;

namespace RazorWebApplication.Pages.Orders;

public class IndexModel : PageModel
{
    public List<Order> Orders { get; set; }
    private readonly PizzaStoreContext _context;

    public IndexModel(PizzaStoreContext context)
    {
        _context = context;    
    }

    public void OnGet()
    {
        int? accountId = HttpContext.Session.GetInt32("accountId");
        Orders = accountId.HasValue
            ? _context.Orders.Where(o => o.CustomerId == accountId).ToList()
            : new List<Order>();
    }

}
