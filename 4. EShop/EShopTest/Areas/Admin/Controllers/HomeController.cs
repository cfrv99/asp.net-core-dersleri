using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopTest.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EShopTest.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private TestOptions options;

        public HomeController(IOptions<TestOptions> options)
        {
            this.options = options.Value;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}