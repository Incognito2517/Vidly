using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Schrek!" };
            return View(movie);
        }

        public ActionResult AllMovies()
        {
            
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie() { Name = "Schrek" });
            movies.Add(new Movie() { Name = "Wall-E" });

            ViewData["movies"] = movies;
            return View();
        }


    }
}