using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopTest.Helpers;
using EShopTest.Models;
using EShopTest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShopTest.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Settings(ProfileSettingsViewModel model)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            user.FullName = model.FullName;

            try
            {
                var filename = FileUploader.UploadFile(model.PhotoUrl);
                user.PhotoUrl = filename;
            }
            catch (Exception)
            {
                ModelState.AddModelError("image", "Image upload failed!");
                return View();
            }
            await userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Profile");
        }
    }
}