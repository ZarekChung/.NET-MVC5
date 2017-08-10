using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyHomework2.Models;

namespace VidlyHomework2.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            Customer customer = new Customer
            {
                Name = "Zarek Chung"
            };
            return View();
        }
    }
}