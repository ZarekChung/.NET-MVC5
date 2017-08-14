using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyHw02.Models;

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
            var customers = GetCustomers();
            //var customers = _context
            return View(customers);

        }
        public ActionResult Details(int Id)
        {

            var customers = GetCustomers().SingleOrDefault(c => c.Id == Id);


            //var customers = tmp.SingleOrDefault(c => c.Id == Id);

            if(customers == null)
                return HttpNotFound();
            return View(customers);
        }


        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Name= "Zarek Chung", Id = 1},
                new Customer { Name = "Simen Chung" ,Id = 2}
            };
        }
    }
}