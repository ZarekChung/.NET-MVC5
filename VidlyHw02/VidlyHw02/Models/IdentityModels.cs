﻿using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VidlyHw02.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{

		[Required]
		[StringLength(50)]
		public string Phone { get; set; }


		[Required]
		[StringLength(255)]
		public string DrivingLicense { get; set; }
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// 注意 authenticationType 必須符合 CookieAuthenticationOptions.AuthenticationType 中定義的項目
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// 在這裡新增自訂使用者宣告
			return userIdentity;
		}
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}
		public DbSet<Movie> Movie { get; set; }
		public DbSet<Customer> Customer { get; set; }

		public DbSet<Genre> Genre { get; set; }
		public DbSet<MembershipType> MembershipType { get; set; }

		public DbSet<Rental> Rental { get; set; }


		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}