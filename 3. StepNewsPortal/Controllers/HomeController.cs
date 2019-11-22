using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StepNewsPortal.Models;

namespace StepNewsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly StepNewsPortalDbContext context;

        public HomeController(StepNewsPortalDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var posts = context.Posts.ToList();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();
            TempData["Created"] = "Post was created";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);
            context.Posts.Remove(post);
            context.SaveChanges();
            TempData["Deleted"] = "Post was deleted";
            return RedirectToAction("Index");
        }

        public IActionResult Post(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);
            return View(post);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
