using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyHw02.Models;

namespace VidlyHw02.Dtos
{
	public class MovieDto
	{

		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }


		public Genre Genre { get; set; }
		[Required]
		public byte GenreId { get; set; }

		public byte NumberAvailable { get; set; }

	
		public DateTime RealeaseDate { get; set; }//= DateTime.Now;

		
		public DateTime DateAdded { get; set; }


		
		public byte NumberInStock { get; set; }

	}
}