using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPagesGuestBook.Areas.Identity.Data;

namespace RazorPagesGuestBook.Models
{
    public class RazorPagesGuestBookContext : IdentityDbContext<AppUser>
    {
        public RazorPagesGuestBookContext(DbContextOptions<RazorPagesGuestBookContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
