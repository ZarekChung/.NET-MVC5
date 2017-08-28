using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyHw02.Models
{
	public class Movie
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		
		public Genre Genre { get; set; }

		public byte GenreId { get; set; }
		
		[Required]
		[Display(Name = "Release Date")]
		public DateTime RealeaseDate { get; set; }

		[Required]
		[Display(Name = "Date Added")]
		public DateTime DateAdded { get; set; }

		[Required]
		[Display(Name = "Number In Stock")]
		public int NumberInStock { get; set; }
	}
}