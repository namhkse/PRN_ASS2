﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorWebApplication.Filters;
using RazorWebApplication.Models;

namespace RazorWebApplication.Pages.Categories
{
    [LoginFilter]
    public class IndexModel : PageModel
    {
        private readonly RazorWebApplication.Models.PizzaStoreContext _context;

        public IndexModel(RazorWebApplication.Models.PizzaStoreContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _context.Categories.ToListAsync();
            }
        }
    }
}
