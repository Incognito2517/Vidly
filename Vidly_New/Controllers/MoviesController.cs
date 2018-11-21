using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly_New.Models;
using Vidly_New.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Schrek!" };
            return View(movie);
        }

        
        public ActionResult AllMovies()
        {

            List<Movie> movies = _context.Movies.Include(c => c.Genre).ToList();
            ViewData["movies"] = movies;
            return View();
        }

        [Route("Movies/Details/{index}")]
        public ActionResult Details(int index)
        {
            ViewData["movies"] = _context.Movies.Include(c => c.Genre).ToList();
            List<Movie> movies = ViewData["movies"] as List<Movie>;
            Movie movie = movies.Where(s => s.Id == index).FirstOrDefault();
            try
            {

                return View(movie);
            }
            catch (ArgumentOutOfRangeException)
            {
                return HttpNotFound();
            }

        }

        [Route("Movies/New")]
        public ActionResult New()
        {
            var AllGenres = _context.Genres.ToList();
            var moviesGenreViewModel = new MoviesGenreViewModel
            {
                Genres = AllGenres
            };

            return View(moviesGenreViewModel);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesGenreViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("New", viewModel);
            }

            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var updatedMovie = _context.Movies.Single(m => m.Id == movie.Id);

                updatedMovie.Name = movie.Name;
                updatedMovie.NumberInStock = movie.NumberInStock;
                updatedMovie.GenreId = movie.GenreId;
                updatedMovie.ReleaseDate = movie.ReleaseDate;
                

            }
            _context.SaveChanges();
            return RedirectToAction("AllMovies", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            
            if(movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MoviesGenreViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("New",viewModel);
        }

    }
}