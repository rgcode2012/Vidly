using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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


        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        /// <summary>
        /// movies
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("PageIndex={0}&SortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+" / "+month);
        }

    }
}