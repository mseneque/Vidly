using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        // Load the DbContext
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // Dispose of the context after use
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var genres = _context.MovieGenres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                MovieGenres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            movie.MovieGenre = _context.MovieGenres.ToList().Single(c => c.Id == movie.MovieGenreId);

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today.Date;
                _context.Movies.Add(movie);
            }                
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(c => c.MovieGenre).SingleOrDefault(c => c.Id == id);
            var genres = _context.MovieGenres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                MovieGenres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(c => c.MovieGenre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        // movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            var movies = _context.Movies.Include(c => c.MovieGenre).ToList();

            return View(movies);
        }

        // movies/released/{year}/{month}
        [Route("movies/released/{year:regex(\\d{4}):range(1950, 2018)}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}