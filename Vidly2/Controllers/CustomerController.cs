using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;

namespace Vidly2.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult ListCustomer()
        {
            var customerList = _context.Customers.Include(c => c.MembershipType).ToList(); //eager loading .Include(c => c.MembershipType)
            return View(customerList);
        }

        public ActionResult DetailCustomer(int id)
        {
            //foreach (var cus in customers)
            //{
            //    if (cus.Id == id)
            //    {
            //        return View(cus);
            //    }
            //}
            //return HttpNotFound();
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomer()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer() {Id = 1, Name = "Alex"},
        //        new Customer() {Id = 2, Name = "John"}
        //    };

        //}
    }
}