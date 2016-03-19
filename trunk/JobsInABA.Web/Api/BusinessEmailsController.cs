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
    public class BusinessEmailsController : ApiController
    {
        private BusinessEmailsRepo db = new BusinessEmailsRepo();

        // GET: api/BusinessEmails
        public IEnumerable<BusinessEmail> GetBusinessEmails()
        {
            return db.GetBusinessEmails();
        }

        // GET: api/BusinessEmails/5
        [ResponseType(typeof(BusinessEmail))]
        public IHttpActionResult GetBusinessEmail(int id)
        {
            BusinessEmail businessEmail = db.GetBusinessEmail(id);

            if (businessEmail == null)
            {
                return NotFound();
            }

            return Ok(businessEmail);
        }

        // PUT: api/BusinessEmails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusinessEmail(int id, BusinessEmail businessEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessEmail.BusinessEmailID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateBusinessEmail(id, businessEmail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessEmailExists(id))
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

        // POST: api/BusinessEmails
        [ResponseType(typeof(BusinessEmail))]
        public IHttpActionResult PostBusinessEmail(BusinessEmail businessEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateBusinessEmail(businessEmail);

            return CreatedAtRoute("DefaultApi", new { id = businessEmail.BusinessEmailID }, businessEmail);
        }

        // DELETE: api/BusinessEmails/5
        [ResponseType(typeof(BusinessEmail))]
        public IHttpActionResult DeleteBusinessEmail(int id)
        {
            var businessEmail = db.DeleteBusinessEmail(id);

            return Ok(businessEmail);
        }

        private bool BusinessEmailExists(int id)
        {
            return db.GetBusinessEmail(id) != null;
        }
    }
}