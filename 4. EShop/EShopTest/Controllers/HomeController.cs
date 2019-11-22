using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShopTest.Models;
using EShopTest.ViewModels;
using Microsoft.AspNetCore.Http;
using EShopTest.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace EShopTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly int itemsPerPage = 6;
        private int page = 1;
        private readonly EShopDbContext context;

        public HomeController(EShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int? id, bool? orderByPrice, int page = 1)
        {
            IEnumerable<Product> products;
            if (id == null)
            {
                products = context.Products;
            }
            else
            {
                products = context.Products.Where(x => x.CategoryId == id);
            }
            ViewBag.TotalPages = Math.Ceiling(products.Count() / (double)itemsPerPage);
 
            if (orderByPrice != null && orderByPrice.Value)
            {
                products = products.OrderByDescending(x => x.Price);
            }
            else if (orderByPrice != null && !orderByPrice.Value)
            {
                products = products.OrderBy(x => x.Price);
            }

            products = products.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            var viewModel = new ProductsViewModel
            {
                Products = products,
                Categories = context.Categories,
                CarouselProducts = context.Products.Where(x => x.ShowInCarousel)
            };
            ViewBag.CurrentPage = page;
            ViewBag.OrderByPrice = orderByPrice;
            return View(viewModel);
        }

        public IActionResult Product(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }

            ViewBag.Categories = context.Categories;
            return View(product);
        }

        public IActionResult Privacy()
        {
            HttpContext.Session.SetString("test", "Hello!");
            return View();
        }

        public IActionResult AddToCart(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            CartStorage.AddToCart(HttpContext.Session, product);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            CartStorage.RemoveFromCart(HttpContext.Session, product);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
