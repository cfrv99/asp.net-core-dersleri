using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGuestBook.Areas.Identity.Data;
using RazorPagesGuestBook.Models;

namespace RazorPagesGuestBook.Pages
{
    public class GuestBookModel : PageModel
    {
        private readonly RazorPagesGuestBookContext context;
        private readonly UserManager<AppUser> userManager;

        public GuestBookModel(
            RazorPagesGuestBookContext context,
            UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [BindProperty]
        public Comment Comment { get; set; }

        public List<Comment> Comments { get; set; }

        public IActionResult OnGet()
        {
            Comments = context.Comments.Include(x => x.AppUser).ToList();
            return Page();
        }

        public IActionResult OnGetByUsername()
        {
            var username = RouteData.Values["username"];

            Comments = context.Comments
                .Include(x => x.AppUser)
                .Where(x => String.Equals(x.AppUser.UserName, username))
                .ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                Comment.AppUser = user;
                Comment.Date = DateTime.Now;
                context.Comments.Add(Comment);

                //context.Comments.Add(new Comment
                //{
                //    Text = Text,
                //    Date = DateTime.Now,
                //    AppUser = user
                //});

                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}