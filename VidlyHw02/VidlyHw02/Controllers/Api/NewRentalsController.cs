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
			var customer = _context.Customer.Single(
				c => c.Id == newRentalDto.CustomerId);

			var movies = _context.Movie.Where(
				m => newRentalDto.MovieIds.Contains(m.Id));

			foreach (var movie in movies)
			{
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
