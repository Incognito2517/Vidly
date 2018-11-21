using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly_New.Dtos;
using Vidly_New.Models;

namespace Vidly_New.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// GET /api/customers
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();


            List<CustomerDto> customerDtos = Mapper.Map<List<Customer>, List<CustomerDto>>(customers);


            return Ok(customerDtos);
        }

        /// <summary>
        /// GET /api/customers/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetCustomers(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        /// <summary>
        /// POST /api/customers/
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        /// <summary>
        /// PUT /api/customers/1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var customerToUpdate = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToUpdate == null)
                return NotFound();

            Mapper.Map<CustomerDto, Customer>(customerDto, customerToUpdate);

            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// DELETE /api/customers/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) {

            var customerToDelete = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToDelete == null)
                return NotFound();

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
            return Ok();
        }
    }
}
