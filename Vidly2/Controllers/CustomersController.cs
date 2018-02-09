using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;
using System.Runtime.Caching;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }  
        public ActionResult New()
        {
            var membershipTypes = new CustomerFormViewModel
            {
                Customer = new Customer(), //property will be intitialize to default customer.Id == 0
                MembershipTypes =  _context.MembershipTypes
            };
            return View("CustomerForm", membershipTypes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };  
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                //updating
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                
                customerInDb.Name = customer.Name;
                customerInDb.Dob = customer.Dob;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("ListCustomer", customer);
        }
        // GET: Customer
        public ActionResult ListCustomer()
        {

            return View();
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}