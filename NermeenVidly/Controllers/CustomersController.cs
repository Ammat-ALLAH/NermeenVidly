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
            Customer Customer = _Context.Customers.SingleOrDefault(C => C.Id == id);

            return View(Customer);
        }


        public ActionResult CustomerForm(int? Id)
        {
            CustomerFormViewModel _CustormerForm = new CustomerFormViewModel {

                
                MembershipTyes = _Context.MembershipTypes.ToList()
        };
            //View Existing Customer object
            if (Id != null && Id != 0)
            {
                //UpdateExisting 
                Customer customer = _Context.Customers.Include(m => m.membershipType).SingleOrDefault(C => C.Id == Id);  
                _CustormerForm.Id = customer.Id;
                _CustormerForm.Birthdate = customer.Birthdate;
                _CustormerForm.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                _CustormerForm.MembershipTypeId = customer.MembershipTypeId;
                _CustormerForm.Name = customer.Name;

            }


            _CustormerForm.MembershipTyes = _Context.MembershipTypes.ToList();
            return View(_CustormerForm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var _CustormerForm = new CustomerFormViewModel
                {
                    MembershipTyes = _Context.MembershipTypes.ToList()
                };
                return View("CustomerForm",_CustormerForm);
            }

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