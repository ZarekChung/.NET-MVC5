using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyHw02.Models
{
	public class CheckStockLimt : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var movie = (Movie)validationContext.ObjectInstance;
			/*if (movie.GenreId == 0)
			{
				//return new ValidationResult("");
				return ValidationResult.Success;
			}*/

			var iStock = movie.NumberInStock;
			return (iStock < Movie.Maxmun && iStock > Movie.Minmun) ? ValidationResult.Success : new ValidationResult("The field Number in Stock must be between 1 and 20.");
		}
	}
}