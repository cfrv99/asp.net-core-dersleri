using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AspMovieSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspMovieSearch.Controllers
{
    public class HomeController : Controller
    {
        readonly string apiKey = "2c9d65d5";

        public async Task<IActionResult> Index(string movie)
        {
            if (movie != null)
            {
                HttpClient httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync($"http://www.omdbapi.com/?apikey={apiKey}&s={movie}"); 

                var result = JsonConvert.DeserializeObject<SearchResult>(json);
                ViewBag.TotalResults = result.totalResults;

                ViewBag.Movies = result.Search;
            }

            return View();
        }

        public async Task<IActionResult> Details(string imdbId)
        {
            if (imdbId != null)
            {
                HttpClient httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync($"http://www.omdbapi.com/?apikey={apiKey}&i={imdbId}");

                var result = JsonConvert.DeserializeObject<Movie>(json);

                ViewBag.Movie = result.Title;
            }

            return View();
        }
    }
}