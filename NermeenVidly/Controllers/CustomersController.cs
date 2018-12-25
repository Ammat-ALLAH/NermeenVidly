using NermeenVidly.Models;
using NermeenVidly.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NermeenVidly.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Customer(string Name)
        {
            Customer C = new Customer();
            C.Name = Name;
            return View(C);
        }
        // GET: Customers
        public ActionResult GetCustomers()
        {
            CustomersViewModuel CustomersVM = new CustomersViewModuel();

            List<Customer> _CustomersList = new List<Customer>()
            {
                new Customer() {Name = "Nermeen!"},
                new Customer() {Name = "Mohammed Said"},
            };
            CustomersVM.CustomersList = _CustomersList;


            return View(CustomersVM);
        }
    }
}