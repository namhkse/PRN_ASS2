using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorWebApplication.Models;

namespace RazorWebApplication.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly RazorWebApplication.Models.PizzaStoreContext _context;

        public IndexModel(RazorWebApplication.Models.PizzaStoreContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get;set; } = default!;

        public async Task OnGetAsync(string name)
        {
            if (_context.Products != null)
            {
                Products = string.IsNullOrEmpty(name)
                ? await _context.Products.Include(p => p.Category).Include(p => p.Supplier).ToListAsync()
                : await _context.Products.Where(p => p.ProductName.Contains(name)).Include(p => p.Category).Include(p => p.Supplier).ToListAsync();
            }
        }
    }
}
