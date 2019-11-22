using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesGuestBook.Areas.Identity.Data;
using RazorPagesGuestBook.Models;

[assembly: HostingStartup(typeof(RazorPagesGuestBook.Areas.Identity.IdentityHostingStartup))]
namespace RazorPagesGuestBook.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RazorPagesGuestBookContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RazorPagesGuestBookContextConnection")));

                services.AddDefaultIdentity<AppUser>()
                    .AddEntityFrameworkStores<RazorPagesGuestBookContext>();
            });
        }
    }
}