using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopTest.Models
{
    public class EShopDbInitializer
    {
        public static async Task SeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                EShopDbContext context = serviceScope
                    .ServiceProvider
                    .GetRequiredService<EShopDbContext>();

                UserManager<AppUser> userManager = serviceScope
                    .ServiceProvider
                    .GetRequiredService<UserManager<AppUser>>();

                RoleManager<IdentityRole> roleManager = serviceScope
                    .ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                } 

                var user = await userManager.FindByNameAsync("admin@eshop.com");
                if (user == null)
                {
                    user = new AppUser
                    {
                        UserName = "admin@eshop.com",
                        Email = "admin@eshop.com"
                    };
                    await userManager.CreateAsync(user, "Secret123$");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
