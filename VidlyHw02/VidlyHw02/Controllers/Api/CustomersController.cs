using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using VidlyHw02.Dtos;
using VidlyHw02.Models;

namespace VidlyHw02.Controllers.Api
{
    public class CustomersController : ApiController
    {
	    private ApplicationDbContext _context;

	    public CustomersController()
	    {
			_context = new ApplicationDbContext();
		    ;
	    }

		// GET /api/customers
		public IHttpActionResult GetCustomers()
		{
			var customerDtos = _context.Customer
				.Include(c => c.MembershipType)
				.ToList()
				.Select(Mapper.Map<Customer, CustomerDTto>);
			//return _context.Customer.ToList().Select(Mapper.Map<Customer,CustomerDTto>);
			return Ok(customerDtos);
		}

		// GET /api/customers/1
		//有點搞不太懂差別??
	    public IHttpActionResult GetCustomer(int id)
	    {
		    var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
		    if (customer == null)
			    return NotFound();
			//throw  new HttpResponseException(HttpStatusCode.NotFound);

			//return Mapper.Map<Customer, CustomerDTto>(customer);
		    return Ok(Mapper.Map<Customer, CustomerDTto>(customer));
	    }

		// POST /api/customers
		[HttpPost]
	    public IHttpActionResult CreateCustomer(CustomerDTto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();
				//throw new HttpResponseException(HttpStatusCode.BadRequest);

		    var customer = Mapper.Map<CustomerDTto, Customer>(customerDto);
		    _context.Customer.Add(customer);
		    _context.SaveChanges();

		    customerDto.Id = customer.Id;

			return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
			//return customerDto;
		}

		// PUT /api/customers/1
	    [HttpPut]
		public void UpdateCustomer(int id, CustomerDTto customerDTto)
	    {
		    if (!ModelState.IsValid)
			    throw new HttpResponseException(HttpStatusCode.BadRequest);

		    var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);
		    if (customerInDb == null)
			    throw new HttpResponseException(HttpStatusCode.NotFound);

		    Mapper.Map(customerDTto, customerInDb);
			/*
		    customerInDb.Name = customer.Name;
		    customerInDb.Birthdate = customer.Birthdate;
		    customerInDb.MembershipTypeId = customer.MembershipTypeId;
		    customerInDb.IsSubscribedToNews = customer.IsSubscribedToNews;
			*/
		    _context.SaveChanges();
	    }

		// DELETE /api/customers/1
		[HttpDelete]
	    public void DeleteCustomer(int id)
	    {
		    var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);
		    if (customerInDb == null)
			    throw new HttpResponseException(HttpStatusCode.NotFound);

		    _context.Customer.Remove(customerInDb);
		    _context.SaveChanges();
	    }


	}
}
