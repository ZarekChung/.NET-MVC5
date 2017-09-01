using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyHw02.Dtos;
using VidlyHw02.Models;

namespace VidlyHw02.Controllers.Api
{
	public class NewRentalsController : ApiController
	{
		private ApplicationDbContext _context;
		public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
		{
			/*
			if(newRentalDto.MovieIds.Count==0)
				return BadRequest("No Movie IDs have been given.");
*/
			var customer = _context.Customer.Single(
				c => c.Id == newRentalDto.CustomerId);
			/*
			if (customer == null)
				return BadRequest("CustomerId is not valid.");
				*/
			var movies = _context.Movie.Where(
				m => newRentalDto.MovieIds.Contains(m.Id)).ToList();
			/*
			if(movies.Count != newRentalDto.MovieIds.Count)
				return BadRequest("One or more MovieIDs are invalid.");
*/
			foreach (var movie in movies)
			{
				if(movie.NumberAvailable == 0)
					return BadRequest("Movie is not available.");

				movie.NumberAvailable--;
				var rental = new Rental
				{
					Customer = customer,
					Movie = movie,
					DateRented = DateTime.Now
				};

				_context.Rental.Add(rental);
			}
			_context.SaveChanges();
			throw new NotImplementedException();
		}
	}
}
