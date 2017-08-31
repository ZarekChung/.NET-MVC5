using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyHw02.Models;
using VidlyHw02.ViewModel;

namespace VidlyHw02.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		//ctor + tab
		public MoviesController()
		{
			_context = new ApplicationDbContext();

		}
		// GET: Movies
		public ActionResult Index()
		{
			var movies = _context.Movie.Include(c => c.Genre).ToList();
			//var customers = _context.Customer.Include(c => c.MembershipType).ToList();
			return View(movies);
		}
		
		//Detail
		public ActionResult Details(int Id)
		{
			var movies = _context.Movie.Include(m => m.Genre).SingleOrDefault(c => c.Id == Id);
			if (movies == null)
				return HttpNotFound();
			return View(movies);
		}

		//new
		public ActionResult New()
		{
			var Genre = _context.Genre.ToList();
			var viewModel = new NewMovieViewModel()
			{
				Movie = new Movie(),
				Genres = Genre
			};

			return View("MovieForm", viewModel);
		}
		[HttpPost]
		public ActionResult Save(Movie movie)
		{
			/*
			movie.DateAdded = DateTime.Now;
			
			_context.Movie.Add(movie);
	*/
			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movie.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movie.Single(m => m.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
				movieInDb.RealeaseDate = movie.RealeaseDate;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Movies");
			
		}
		public ActionResult DeletMovie(int id)
		{
			var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);
			if (movieInDb == null)
				return HttpNotFound();

			_context.Movie.Remove(movieInDb);
			_context.SaveChanges();
			return RedirectToAction("Index", "Movies");
		}
		public ActionResult Edit(int id)
		{
			var movie = _context.Movie.SingleOrDefault(c => c.Id == id);

			if (movie == null)
				return HttpNotFound();
			var viewmodel = new NewMovieViewModel()
			{
				Movie = movie,
				Genres = _context.Genre.ToList()
			};
			return View("MovieForm", viewmodel);
		}
		
	}
}