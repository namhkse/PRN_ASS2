using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplication.Models;

namespace RazorWebApplication.Pages.Register;

public class IndexModel : PageModel
{
    private readonly PizzaStoreContext _context;

    [BindProperty]
    [Required]
    public string Username { get; set; }

    [BindProperty]
    [Required]
    public string FullName { get; set; }

    [BindProperty]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string RegisterMessage = string.Empty;

    public IndexModel(PizzaStoreContext context)
    {
        _context = context;
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            var account = new Account();
            account.FullName = FullName;
            account.UserName = Username;
            account.Password = Password;
            account.Type = 0;

            if (IsAccountExist(Username))
            {
                RegisterMessage = "Username was taken by other account. Please choose different username!";
            }
            else
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                RegisterMessage = "Register Successfully!";
            }
        }
    }

    private bool IsAccountExist(string username)
    {
        return _context.Accounts.FirstOrDefault(a => a.UserName.Equals(username)) != null;
    }
}