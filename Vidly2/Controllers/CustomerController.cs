using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult ListCustomer()
        {
            var customerList = GetCustomer();
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
            var customer = GetCustomer().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomer()
        {
            return new List<Customer>
            {
                new Customer() {Id = 1, Name = "Alex"},
                new Customer() {Id = 2, Name = "John"}
            };

        }
    }
}