using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VidlyHw02.Dtos;
using VidlyHw02.Models;

namespace VidlyHw02.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<Customer, CustomerDTto>();
			Mapper.CreateMap<CustomerDTto,Customer>();
			Mapper.CreateMap<MembershipType, MembershipTypeDto>();


			Mapper.CreateMap<Movie, MovieDto>();
			Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
			//Mapper.CreateMap<MovieDto, Movie>();
			//Mapper.CreateMap<Genre, GenreDto>();

			/*
			//Dot
			Mapper.CreateMap<CustomerDTto, Customer>()
				.ForMember(c => c.Id, opt => opt.Ignore());
				*/
		}
	}
}