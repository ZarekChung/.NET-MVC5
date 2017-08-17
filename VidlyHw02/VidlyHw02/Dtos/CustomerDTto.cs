using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyHw02.Models;

namespace VidlyHw02.Dtos
{
	public class CustomerDTto
	{
		public int Id { get; set; }
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNews { get; set; }

		public byte MembershipTypeId { get; set; }

		[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}