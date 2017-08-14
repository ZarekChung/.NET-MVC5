using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Moive/Random

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Zarek!!" };

            //ViewModel
            var customers = new List<Customer>
            {
                new Customer { Name= "customer 1"},
                new Customer { Name = "customer 2" }

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //return type
            //return RedirectToAction("Index", "Home", new {page = 1, sortby="name"});
            //return new EmptyResult();
            //return HttpNotFound();
            //return Content("Hello World!");

            //ViewDate and ViewBag
            ViewData["RandomMovie"] = movie;
            ViewBag.RandomMovie = movie;

            return View(viewModel);
        }


        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace((sortBy)))
                sortBy = "name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}