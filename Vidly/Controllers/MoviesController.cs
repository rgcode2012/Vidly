using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

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
        public ViewResult Index()
        {
            var movies = _context.Movies.Include("Genre").ToList(); ;

            return View(movies);
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }




        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include("Genre").FirstOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
            }
           

            return RedirectToAction("Index", "Movies");
        }
    



// GET: Movies
public ActionResult Random()
{
    var movie = new Movie() { Name = "Shrek!" };
    return View(movie);
    //return HttpNotFound("Not Found");
    //return new EmptyResult();
    //return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });
}

public ActionResult RandomData()
{
    var movie = new Movie() { Name = "Shrek!" };
    ViewData["Movie"] = movie;

    return View();
}

public ActionResult RandomMovies()
{
    var movie = new Movie() { Name = "Shrek!" };
    var customers = new List<Customer>
            {
                new Customer {Name="Customer1" },
                new Customer {Name="Customer2" }
            };

    var viewModel = new RandomMovieViewModel
    {
        Movie = movie,
        Customers = customers
    };

    return View(viewModel);
}


//public ActionResult Edit(int id)
//{
//    return Content("id = " + id);
//}

/// <summary>
/// movies
/// </summary>
/// <returns></returns>
//public ActionResult Index(int? pageIndex,string sortBy)
//{
//    if (!pageIndex.HasValue)
//        pageIndex = 1;

//    if (String.IsNullOrWhiteSpace(sortBy))
//        sortBy = "Name";

//    return Content(String.Format("PageIndex={0}&SortBy={1}", pageIndex, sortBy));
//}



[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
public ActionResult ByReleaseDate(int year, int month)
{
    return Content(year + " / " + month);
}

    }
}