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
using JobsInABA.Workflows;
using JobsInABA.BL.DTOs;

namespace Api.Controllers
{
    public class BusinessEmailsController : ApiController
    {
        private BusinessEmailsWorkflows db = new BusinessEmailsWorkflows();

        // GET: api/BusinessEmails
        public IEnumerable<BusinessEmailDTO> GetBusinessEmails()
        {
            return db.Get();
        }

        // GET: api/BusinessEmails/5
        [ResponseType(typeof(BusinessEmailDTO))]
        public IHttpActionResult GetBusinessEmail(int id)
        {
            BusinessEmailDTO businessEmail = db.Get(id);

            if (businessEmail == null)
            {
                return NotFound();
            }

            return Ok(businessEmail);
        }

        // PUT: api/BusinessEmails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusinessEmail(int id, BusinessEmailDTO businessEmail)
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
                db.Update(businessEmail);
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
        [ResponseType(typeof(BusinessEmailDTO))]
        public IHttpActionResult PostBusinessEmail(BusinessEmailDTO businessEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(businessEmail);

            return CreatedAtRoute("DefaultApi", new { id = businessEmail.BusinessEmailID }, businessEmail);
        }

        // DELETE: api/BusinessEmails/5
        [ResponseType(typeof(BusinessEmailDTO))]
        public IHttpActionResult DeleteBusinessEmail(int id)
        {
            var businessEmail = db.Delete(id);

            return Ok(businessEmail);
        }

        private bool BusinessEmailExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}