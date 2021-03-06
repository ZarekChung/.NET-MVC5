﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyHw02.Models
{
	public class MembershipType
	{
		public byte Id { get; set; }
		public string Name { get; set; }
		public short SingUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRate { get; set; }

		public static readonly byte Uknow = 0;
		public static readonly byte PayasYou = 1;
	}
}