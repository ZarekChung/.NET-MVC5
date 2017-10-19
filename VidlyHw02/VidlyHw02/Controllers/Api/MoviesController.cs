using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyHw02.Models;
using System.Data.Entity;
using VidlyHw02.Dtos;
using AutoMapper;

namespace VidlyHw02.Controllers.Api
{
	public class MoviesController : ApiController
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}
		// GET /api/movies
		public IHttpActionResult GetMovies()
		{
			var movieDtos = _context.Movie
				.Include(c => c.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
			return Ok(movieDtos);
		}

		// GET /api/movies/1
		public IHttpActionResult GetMovie(int Id)
		{
			var movie = _context.Movie.SingleOrDefault(c => c.Id == Id);

			if(movie ==null)
				return NotFound();

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		// POST /api/movie
		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if(!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);

			_context.Movie.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;
			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}
	
		// PUT /api/movie/1
		public void UpdateMovie(int Id, Movie movieDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == Id);

			if (movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			Mapper.Map(movieDto, movieInDb);
			

			_context.SaveChanges();

		}
		// DELETE /api/movie/1
		[HttpDelete]
		public void DeleteMovie(int Id)
		{
			var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == Id);
			if (movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Movie.Remove(movieInDb);
			_context.SaveChanges();
		}
		
	}


}
