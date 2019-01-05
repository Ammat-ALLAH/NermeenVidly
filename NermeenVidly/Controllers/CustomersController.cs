using NermeenVidly.Models;
using NermeenVidly.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
    

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
            Customer Customer = _Context.Customers.SingleOrDefault(C => C.Id == id);

            return View(Customer);
        }


        public ActionResult New(int? Id)
        {
            CustomerFormViewModel _CustormerForm = new CustomerFormViewModel();
            //View Existing Customer object
            if (Id != 0)
            {
                //UpdateExisting 
                Customer customer = _Context.Customers.Include(m => m.membershipType).SingleOrDefault(C => C.Id == Id);
                _CustormerForm.customer = customer;
            }


            _CustormerForm.MembershipTyes = _Context.MembershipTypes.ToList();
            return View(_CustormerForm);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id != 0)
            {
                Customer CustomerToEdit = _Context.Customers.SingleOrDefault(C => C.Id == customer.Id);
                CustomerToEdit.Name = customer.Name;
                CustomerToEdit.MembershipTypeId = customer.MembershipTypeId;
                CustomerToEdit.Birthdate = customer.Birthdate;
                CustomerToEdit.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            else
            {
                _Context.Customers.Add(customer);
            }

            _Context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

    }
}