using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> allCustomers =
            new List<Customer>() { new Customer() { Name = "John Smith" },
            new Customer() { Name = "Mary Williams" } };


        // GET: Customers
        public ActionResult Index()
        {
          
            ViewData["Customers"] = allCustomers;
            return View();
        }

        [Route("Customers/Details/{index}")]
        public ActionResult Details(int index)
        {
            try
            {
                return View(allCustomers[index]);
            }
            catch ( ArgumentOutOfRangeException)
            {
                return HttpNotFound();
            }
           
        }
    }
}