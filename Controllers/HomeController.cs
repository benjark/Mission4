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
        private MovieContext daContext { get; set; }

        public HomeController(MovieContext temp)
        {
            daContext = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Index(MovieModel sq)
        {
            daContext.Add(sq);
            daContext.SaveChanges();

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
            daContext.Add(sq);
            daContext.SaveChanges();

            return View();
        }


        [HttpGet]
        public IActionResult MovieList (MovieModel sq)
        {
            var movies = daContext.Movies
                //.Where(blah => blah.LentTo == false)
                .OrderBy(m => m.Title)
                .ToList();

            return View(movies);
            
        }

        public IActionResult EditMovie (int movieid)
        {
            return View();
        }
    }
}
