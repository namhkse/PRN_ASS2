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
        [BindProperty] public string SearchPizzaName { get; set; }

        private readonly RazorWebApplication.Models.PizzaStoreContext _context;

        public IndexModel(RazorWebApplication.Models.PizzaStoreContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = default!;

        public async Task OnGetAsync(int? categoryId)
        {
            if (_context.Products != null)
            {
                Products = (categoryId != null)
                    ? await _context.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category).Include(p => p.Supplier).ToListAsync()
                    : await _context.Products.Include(p => p.Category).Include(p => p.Supplier).ToListAsync();
            }
        }

        public async Task OnPostAsync()
        {
            if (_context.Products != null)
            {
                if (string.IsNullOrEmpty(SearchPizzaName))
                {
                    Products = await _context.Products
                        .Include(p => p.Category).Include(p => p.Supplier).ToListAsync();
                }
                else
                {
                    Products = await _context.Products
                        .Where(p => p.ProductName.Contains(SearchPizzaName)).Include(p => p.Category)
                        .Include(p => p.Supplier).ToListAsync();
                }
            }
        }
    }
}
