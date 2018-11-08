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
            var movie_1 = new Movie();
            var movieShreck = new Movie() { Name = "Schrek" };
            var movieWallE = new Movie() { Name = "Wall-E" };
            movie_1.movies.Add(movieShreck);
            movie_1.movies.Add(movieWallE);
            return View(movie_1);
        }


    }
}