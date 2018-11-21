using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly_New.Models;
using Vidly_New.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    


        // GET: Customers
        public ActionResult Index()
        {

            ViewData["Customers"] = _context.Customers.Include(c => c.MembershipType).ToList();

            return View();
        }

        [Route("Customers/Details/{index}")]
        public ActionResult Details(int index)
        {
            ViewData["Customers"] = _context.Customers.Include(c => c.MembershipType).ToList();
            List<Customer> customers = ViewData["Customers"] as List<Customer>;
            Customer customer = customers.Where(s => s.Id == index).FirstOrDefault();
            try
            {

                return View(customer);
            }
            catch ( ArgumentOutOfRangeException)
            {
                return HttpNotFound();
            }
           
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerMemebrshipTypeViewModel
            {
                MembershipTypes = membershipTypes,
                

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerMemebrshipTypeViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("New", viewModel);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerMemebrshipTypeViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
        }
    }
}