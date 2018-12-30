using NermeenVidly.Models;
using NermeenVidly.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace NermeenVidly.Controllers
{
    public class CustomersController : Controller
    {

        ApplicationDbContext _Context;
        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            CustomersViewModuel CustomersVM = new CustomersViewModuel();

            CustomersVM.CustomersList = _Context.Customers.Include(C => C.membershipType).ToList();

            return View(CustomersVM);
        }
        // GET: Customers
        public ActionResult Details(int id)
        {
            Customer Customer = _Context.Customers.SingleOrDefault( C=>C.Id == id);

            return View(Customer);
        }
    }
}