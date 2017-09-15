using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyHw02.Models
{
	public class Movie
	{
		public Movie()
		{
			RealeaseDate = DateTime.Now;
		}
		[Required]
		public int Id { get; set; }

		[Required(ErrorMessage = "The Name is Required")]
		public string Name { get; set; }
		
		public Genre Genre { get; set; }

		[Required(ErrorMessage = "The  Genre is Required")]
		[CheckStockLimt]
		public byte GenreId { get; set; }
		
		public byte NumberAvailable { get; set; }

		[Required(ErrorMessage = "The Release Date is Required")]
		[Display(Name = "Release Date")]
		public DateTime RealeaseDate { get; set; }//= DateTime.Now;

		[Required]
		[Display(Name = "Date Added")]
		public DateTime DateAdded { get; set; }

		[Display(Name = "Number In Stock")]
		[CheckStockLimt]
		public int NumberInStock { get; set; }

		public static readonly byte minmun = 1;
		public static readonly byte maxmun = 20;


	}
}