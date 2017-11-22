using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CustomerApi.Models;

namespace CustomerApi.Controllers
{
    public class CustomerDataController : ApiController
    {
        private LeeCustomerDataEntities db = new LeeCustomerDataEntities();

        // GET: api/CustomerData
        public IQueryable<CustomerData> GetCustomerData()
        {
            return db.CustomerData;
        }

        // GET: api/CustomerData/5
        [ResponseType(typeof(CustomerData))]
        public IHttpActionResult GetCustomerData(int id)
        {
            CustomerData customerData = db.CustomerData.Find(id);
            if (customerData == null)
            {
                return NotFound();
            }

            return Ok(customerData);
        }


        // PUT: api/CustomerData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerData(int id, CustomerData customerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerData.CustomerId)
            {
                return BadRequest();
            }

            db.Entry(customerData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerData
        [ResponseType(typeof(CustomerData))]
        public IHttpActionResult PostCustomerData(CustomerData customerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerData.Add(customerData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerData.CustomerId }, customerData);
        }

        // DELETE: api/CustomerData/5
        [ResponseType(typeof(CustomerData))]
        public IHttpActionResult DeleteCustomerData(int id)
        {
            CustomerData customerData = db.CustomerData.Find(id);
            if (customerData == null)
            {
                return NotFound();
            }

            db.CustomerData.Remove(customerData);
            db.SaveChanges();

            return Ok(customerData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerDataExists(int id)
        {
            return db.CustomerData.Count(e => e.CustomerId == id) > 0;
        }
    }
}