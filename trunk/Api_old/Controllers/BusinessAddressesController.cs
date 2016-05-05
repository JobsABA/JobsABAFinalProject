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
using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;

namespace Api.Controllers
{
    public class BusinessAddressesController : ApiController
    {
        private BusinessAddressesRepo db = new BusinessAddressesRepo();

        // GET: api/BusinessAddresses
        public IEnumerable<BusinessAddress> GetBusinessAddresses()
        {
            return db.GetBusinessAddresses();
        }

        // GET: api/BusinessAddresses/5
        [ResponseType(typeof(BusinessAddress))]
        public IHttpActionResult GetBusinessAddress(int id)
        {
            BusinessAddress businessAddress = db.GetBusinessAddress(id);
            if (businessAddress == null)
            {
                return NotFound();
            }

            return Ok(businessAddress);
        }

        // PUT: api/BusinessAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusinessAddress(int id, BusinessAddress businessAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessAddress.BusinessAddressID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateBusinessAddress(id, businessAddress);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessAddressExists(id))
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

        // POST: api/BusinessAddresses
        [ResponseType(typeof(BusinessAddress))]
        public IHttpActionResult PostBusinessAddress(BusinessAddress businessAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateBusinessAddress(businessAddress);

            return CreatedAtRoute("DefaultApi", new { id = businessAddress.BusinessAddressID }, businessAddress);
        }

        // DELETE: api/BusinessAddresses/5
        [ResponseType(typeof(BusinessAddress))]
        public IHttpActionResult DeleteBusinessAddress(int id)
        {
            var businessAddress = db.DeleteBusinessAddress(id);
            return Ok(businessAddress);
        }

        private bool BusinessAddressExists(int id)
        {
            return (db.GetBusinessAddress(id) != null);
        }
    }
}