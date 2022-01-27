using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }

        public HomeController(MovieContext temp)
        {
            context = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Index(MovieModel sq)
        {
            context.Add(sq);
            context.SaveChanges();

            return View();
        }
        
        public IActionResult Podcasts()
        {
            return View();

        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddMovie(MovieModel sq)
        {
            context.Add(sq);
            context.SaveChanges();

            return View();
        }
    }
}
