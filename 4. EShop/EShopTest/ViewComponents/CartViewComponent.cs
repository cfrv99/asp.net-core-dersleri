using EShopTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopTest.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> cart = null;
            try
            {
                var json = HttpContext.Session.GetString("cart");
                cart = JsonConvert.DeserializeObject<List<Product>>(json);
                ViewBag.Cart = cart.Count();
            }
            catch (Exception)
            {
                ViewBag.Cart = 0;
            }

            return View(cart);
        }
    }
}
