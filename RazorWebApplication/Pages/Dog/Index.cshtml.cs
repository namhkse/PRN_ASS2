using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebApplication.Pages.Dog;

public class IndexModel : PageModel
{
    [BindProperty] public string Name { get; set; }

    public void OnGet()
    {
        System.Console.WriteLine("get " + Name);
    }
}

