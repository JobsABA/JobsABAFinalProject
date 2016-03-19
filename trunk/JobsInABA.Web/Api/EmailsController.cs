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
    public class EmailsController : ApiController
    {
        private EmailsRepo db = new EmailsRepo();

        // GET: api/Emails
        public IEnumerable<Email> GetEmails()
        {
            return db.GetEmail();
        }

        // GET: api/Emails/5
        [ResponseType(typeof(Email))]
        public IHttpActionResult GetEmail(int id)
        {
            Email email = db.GetEmailByID(id);
            if (email == null)
            {
                return NotFound();
            }

            return Ok(email);
        }

        // PUT: api/Emails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmail(int id, Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != email.EmailID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateEmail(email);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        // POST: api/Emails
        [ResponseType(typeof(Email))]
        public IHttpActionResult PostEmail(Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.CreateEmail(email);
            }
            catch (DbUpdateException)
            {
                if (EmailExists(email.EmailID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = email.EmailID }, email);
        }

        // DELETE: api/Emails/5
        [ResponseType(typeof(Email))]
        public IHttpActionResult DeleteEmail(int id)
        {
            return db.DeleteEmail(id) ? Ok(true) : Ok(false);
        }

        private bool EmailExists(int id)
        {
            return db.GetEmailByID(id) != null;
        }
    }
}