using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categorys = daContext.Categorys.ToList();

            return View();

        }
        [HttpPost]
        public IActionResult AddMovie(MovieModel sq)
        {
            daContext.Add(sq);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


        [HttpGet]
        public IActionResult MovieList (MovieModel sq)
        {
            var movies = daContext.Movies
                .Include(c => c.Category)
                //.Where(blah => blah.LentTo == false)
                .OrderBy(m => m.Title)
                .ToList();
            
            return View(movies);
            
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categorys = daContext.Categorys.ToList();
            var movie = daContext.Movies.Single(m => m.MovieID == movieid);
            return View("MovieList", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieContext mc)
        {
            ViewBag.Categorys = daContext.Categorys.ToList();
            daContext.Update(mc);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = daContext.Movies.Single(m => m.MovieID == movieid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieModel mm)
        {
            daContext.Movies.Remove(mm);
            daContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
