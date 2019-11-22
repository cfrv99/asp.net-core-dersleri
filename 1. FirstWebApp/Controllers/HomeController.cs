using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        // /Home/Index
        public IActionResult Index()
        {
            ViewBag.Data = new List<string> { "One", "Two", "Three" };

            return View();
        }

        // /Home/Index
        public IActionResult Contacts()
        {
            string phoneNumber = "051237458732";
            ViewData["Phone"] = phoneNumber;

            string address = "Baku";
            ViewBag.Address = address;

            TempData["Message"] = "Message from contacts!";

            return View();
        }

        public IActionResult Data(int id, string text = "Empty")
        {
            ViewBag.Text = text;
            ViewBag.Id = id;
            return View();
        }

        public IActionResult Search(string searchText)
        {
            ViewBag.SearchText = searchText;
            return View();
        }

        public IActionResult About(Person person)
        {
            ViewBag.Person = person;
            return View();
        }

        public IActionResult Error(int code)
        {
            ViewBag.Code = code;
            return View();
        }
    }
}
