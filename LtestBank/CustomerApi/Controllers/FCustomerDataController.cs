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
    public class FCustomerDataController : ApiController
    {
        private LeeCustomerDataEntities2 db = new LeeCustomerDataEntities2();

        // GET: api/FCustomerData
        public IQueryable<FCustomerData> GetFCustomerData()
        {
            return db.FCustomerData;
        }

        // GET: api/FCustomerData/5
        [ResponseType(typeof(FCustomerData))]
        public IHttpActionResult GetFCustomerData(int id)
        {
            FCustomerData fCustomerData = db.FCustomerData.Find(id);
            if (fCustomerData == null)
            {
                return NotFound();
            }

            return Ok(fCustomerData);
        }

        // PUT: api/FCustomerData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFCustomerData(int id, FCustomerData fCustomerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fCustomerData.Id)
            {
                return BadRequest();
            }

            db.Entry(fCustomerData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FCustomerDataExists(id))
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

        // POST: api/FCustomerData
        [ResponseType(typeof(FCustomerData))]
        public IHttpActionResult PostFCustomerData(FCustomerData fCustomerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FCustomerData.Add(fCustomerData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FCustomerDataExists(fCustomerData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fCustomerData.Id }, fCustomerData);
        }

        // DELETE: api/FCustomerData/5
        [ResponseType(typeof(FCustomerData))]
        public IHttpActionResult DeleteFCustomerData(int id)
        {
            FCustomerData fCustomerData = db.FCustomerData.Find(id);
            if (fCustomerData == null)
            {
                return NotFound();
            }

            db.FCustomerData.Remove(fCustomerData);
            db.SaveChanges();

            return Ok(fCustomerData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FCustomerDataExists(int id)
        {
            return db.FCustomerData.Count(e => e.Id == id) > 0;
        }
    }
}