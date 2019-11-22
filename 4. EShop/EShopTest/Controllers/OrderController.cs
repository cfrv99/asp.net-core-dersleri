using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopTest.Helpers;
using EShopTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShopTest.Controllers
{
    public class OrderController : Controller
    {
        private readonly EShopDbContext context;

        public OrderController(EShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult NewOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewOrder(Order order)
        {
            var resultOrder = context.Orders.Add(order).Entity;
            context.SaveChanges();

            var cartProducts = CartStorage.GetCartProducts(HttpContext.Session);
            foreach (var item in cartProducts)
            {
                context.OrderProducts.Add(new OrderProduct { ProductId = item.Id, OrderId = resultOrder.Id });
            }
            context.SaveChanges();

            CartStorage.ClearCart(HttpContext.Session);

            TempData["Order"] = $"Your order is placed! Your order ID: {resultOrder.Id}";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult OrderStatus(int id)
        {
            var order = context.Orders.FirstOrDefault(x => x.Id == id);
            ViewBag.Status = order.IsDone;

            var products = context.OrderProducts
                .Include(x => x.Product)
                .Where(x => x.OrderId == id)
                .Select(x => x.Product);

            return View(products);
        }
    }
}