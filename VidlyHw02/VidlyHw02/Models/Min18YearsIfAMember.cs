using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyHw02.Models
{
	public class Min18YearsIfAMember:ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer) validationContext.ObjectInstance;

			if (customer.MembershipTypeId == MembershipType.Uknow
				|| customer.MembershipTypeId == MembershipType.PayasYou)
			{
				return ValidationResult.Success;
			}
			//????
			if (customer.Birthdate == null)
			{
				return new ValidationResult("Birthdate is require");
			}

			var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
			return (age >= 18)
				? ValidationResult.Success
				: new ValidationResult("you should over at least 18");
		}
	}
}