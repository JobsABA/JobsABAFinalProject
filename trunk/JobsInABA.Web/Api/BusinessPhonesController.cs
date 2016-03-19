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
    public class BusinessPhonesController : ApiController
    {
        private BusinessPhonesRepo db = new BusinessPhonesRepo();

        // GET: api/BusinessPhones
        public IEnumerable<BusinessPhone> GetBusinessPhones()
        {
            return db.GetBusinessPhones();
        }

        // GET: api/BusinessPhones/5
        [ResponseType(typeof(BusinessPhone))]
        public IHttpActionResult GetBusinessPhone(int id)
        {
            BusinessPhone businessPhone = db.GetBusinessPhone(id);
            if (businessPhone == null)
            {
                return NotFound();
            }

            return Ok(businessPhone);
        }

        // PUT: api/BusinessPhones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusinessPhone(int id, BusinessPhone businessPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessPhone.BusinessPhoneID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateBusinessPhone(id, businessPhone);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessPhoneExists(id))
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

        // POST: api/BusinessPhones
        [ResponseType(typeof(BusinessPhone))]
        public IHttpActionResult PostBusinessPhone(BusinessPhone businessPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateBusinessPhone(businessPhone);

            return CreatedAtRoute("DefaultApi", new { id = businessPhone.BusinessPhoneID }, businessPhone);
        }

        // DELETE: api/BusinessPhones/5
        [ResponseType(typeof(BusinessPhone))]
        public IHttpActionResult DeleteBusinessPhone(int id)
        {
            var businessPhone = db.DeleteBusinessPhone(id);

            return Ok(businessPhone);
        }

        private bool BusinessPhoneExists(int id)
        {
            return db.GetBusinessPhone(id) != null;
        }
    }
}