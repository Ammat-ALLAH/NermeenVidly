using AutoMapper;
using NermeenVidly.DTOs;
using NermeenVidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NermeenVidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _Context;
        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }
        // GET /api/Customers
        public IHttpActionResult GetCustomers()
        {
            var Customers = _Context.Customers;
            if (Customers == null)
                return NotFound();
            return Ok( Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>));
        }
        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var CustomerInDB = _Context.Customers.SingleOrDefault(C => C.Id == id);

            if (CustomerInDB is null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDTO>(CustomerInDB));
        }

        // Save /api/Customers
        [HttpPost] 
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (customerDto is null)
                return BadRequest();

            Customer customer = Mapper.Map<CustomerDTO, Customer> (customerDto);
            _Context.Customers.Add(customer);
            _Context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri +"/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDTO customer)
        {
            var CustomerInDB = _Context.Customers.SingleOrDefault(C => C.Id == id);

            if (CustomerInDB is null)
                return NotFound();

            Mapper.Map(customer, CustomerInDB);
            _Context.SaveChanges();

            return Ok();
        }

        // Delete /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var CustomerInDB = _Context.Customers.SingleOrDefault(C => C.Id == id);

            if (CustomerInDB is null)
                return NotFound();
            _Context.Customers.Remove(CustomerInDB);
            _Context.SaveChanges();

            return Ok();
        }

    }
}
