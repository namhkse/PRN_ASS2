using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplication.Models;

namespace RazorWebApplication.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly RazorWebApplication.Models.PizzaStoreContext _context;

        public string LoginMessage;
        [BindProperty] public string Username {get; set;}
        [BindProperty] public string Password {get; set;}

        public IndexModel(PizzaStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var account = _context.Accounts.FirstOrDefault(a => a.UserName.Equals(Username) && a.Password.Equals(Password));

            if (account == null)
            {
                LoginMessage = "Wrong username or password!"; 
                return Page();
            }
            else
            {
                return Redirect("/Products");
            }
        }
    }
}