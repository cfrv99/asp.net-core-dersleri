using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesGuestBook.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; } = "Guest";

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                Name = User.Identity.Name;
            }
        }
    }
}
