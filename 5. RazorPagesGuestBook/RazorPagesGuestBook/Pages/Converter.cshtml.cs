using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesGuestBook.Pages
{
    public class ConverterModel : PageModel
    {
        [BindProperty]
        public decimal Azn { get; set; }

        public decimal Result { get; set; }

        public void OnPost()
        {
            if (Azn != 0)
            {
                Result = Azn / 1.7m;
            }
        }
    }
}