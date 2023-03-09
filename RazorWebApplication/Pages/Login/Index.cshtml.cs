using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplication.Models;

namespace RazorWebApplication.Pages.Login
{
    public class IndexModel : PageModel
    {
        [BindProperty] public string LoginMessage{get; set;}
        [BindProperty] public string Username {get; set;}
        [BindProperty] public string Password {get; set;}

        private readonly RazorWebApplication.Models.PizzaStoreContext _context;

        public IndexModel(PizzaStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGetLogout()
        {
            ClearSession();
            return Redirect("/Products");
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
                SetAccountToSession(account);
                return Redirect("/Products");
            }
        }

        private void SetAccountToSession(Account account)
        {
            var session = HttpContext.Session;
            session.SetString("username", account.UserName);
            session.SetInt32("logged", 1);
            session.SetInt32("accountType", account.Type);
        }

        private void ClearSession()
        {
            HttpContext.Session.Clear();
        }
    }
}