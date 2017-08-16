using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using VidlyHw02.Models;
using VidlyHw02.ViewModel;

namespace VidlyHw02.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context= new ApplicationDbContext();
            ;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
           // var customers = GetCustomers();
            var customers = _context.Customer.Include(c => c.MembershipType).ToList();
            return View(customers);

        }
        public ActionResult Details(int Id)
        {

            //var customers = GetCustomers().SingleOrDefault(c => c.Id == Id);
            var customers = _context.Customer.SingleOrDefault(c => c.Id == Id);

            //var customers = tmp.SingleOrDefault(c => c.Id == Id);

            if (customers == null)
                return HttpNotFound();
            return View(customers);
        }

        public ActionResult New()
        {
	        var membershipType = _context.MembershipType.ToList();
	        var viewModel = new NewCustomerViewModel()
	        {
				Customer = new Customer(),
		        MembershipTypes = membershipType
	        };

			return View("CustomerForm", viewModel);
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new NewCustomerViewModel()
				{
					Customer = customer,
					MembershipTypes = _context.MembershipType.ToList()
				};
				return View("CustomerForm", viewModel);
			}

			if (customer.Id == 0)
				_context.Customer.Add(customer);
			else
			{
				var customerInDb = _context.Customer.Single(c => c.Id == customer.Id);
				//Mapper.Map(customer, customerInDb)
				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNews = customer.IsSubscribedToNews;
				//TryUpdateModel(customerInDb);
			}
			_context.SaveChanges();

			return RedirectToAction("Index","Customers");
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();
			var viewmodel = new NewCustomerViewModel()
			{
				Customer = customer,
				MembershipTypes = _context.MembershipType.ToList()
			};
			return View("CustomerForm", viewmodel);
		}
        /*
        private IEnumerabl
        e<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Name= "Zarek Chung", Id = 1},
                new Customer { Name = "Simen Chung" ,Id = 2}
            };
        }
        */
    }
}