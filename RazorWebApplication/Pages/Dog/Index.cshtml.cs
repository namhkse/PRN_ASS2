using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebApplication.Pages.Dog
{
    public class IndexModel : PageModel
    {
        [BindProperty] public string Name {get; set;}

        public async Task OnGetAsync()
        {
            System.Console.WriteLine("abc");
        }

        public void OnPostDelete() {
            System.Console.WriteLine("delete post");
        }

        public void OnPostEdit() {
            System.Console.WriteLine("edit post");
        }
    }
}
