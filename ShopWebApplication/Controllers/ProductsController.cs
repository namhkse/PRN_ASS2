using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopWebApplication.Filters;
using ShopWebApplication.Models;

namespace ShopWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PizzaStoreContext _context;

        public ProductsController(PizzaStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Product, Supplier> pizzas = _context.Products.Include(p => p.Category).Include(p => p.Supplier);
                return View(await pizzas.ToListAsync());
            }
            ViewData["pizzaName"] = name;
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Product, Supplier> pizzaStoreContext = _context.Products.Where(i => i.ProductName.Contains(name))
                .Include(p => p.Category).Include(p => p.Supplier);
            return View(await pizzaStoreContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            Product? product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            return product == null ? NotFound() : View(product);
        }

        [LoginFilter]
        [AccountTypeFilter(1, 2)]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        [HttpPost]
        [LoginFilter]
        [AccountTypeFilter(1, 2)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,ProductImage,ProductId,Description")] Product product)
        {
            ModelState.Remove("Category");
            ModelState.Remove("Supplier");
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", product.SupplierId);
            return View(product);
        }

        [LoginFilter]
        [AccountTypeFilter(1, 2)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            Product? product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", product.SupplierId);
            return View(product);
        }

        [HttpPost]
        //[AccountTypeFilter(1, 2)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,ProductImage,ProductId,Description")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            ModelState.Remove("Category");
            ModelState.Remove("Supplier");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", product.SupplierId);
            return View(product);
        }

        [LoginFilter]
        [AccountTypeFilter(1)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            Product? product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            return product == null ? NotFound() : View(product);
        }

        [LoginFilter]
        [AccountTypeFilter(1)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'PizzaStoreContext.Products'  is null.");
            }
            Product? product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        [LoginFilter]
        public async Task<IActionResult> Manage()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Product, Supplier> pizzas = _context.Products.Include(p => p.Category).Include(p => p.Supplier);
            return View(await pizzas.ToListAsync());
        }
    }
}
