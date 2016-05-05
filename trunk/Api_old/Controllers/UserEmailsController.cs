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
    public class UserEmailsController : ApiController
    {
        private UserEmailsWorkflows db = new UserEmailsWorkflows();

        // GET: api/UserEmails
        public IEnumerable<UserEmailDTO> GetUserEmails()
        {
            return db.Get();
        }

        // GET: api/UserEmails/5
        [ResponseType(typeof(UserEmailDTO))]
        public IHttpActionResult GetUserEmail(int id)
        {
            UserEmailDTO userEmail = db.Get(id);
            if (userEmail == null)
            {
                return NotFound();
            }

            return Ok(userEmail);
        }

        // PUT: api/UserEmails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserEmail(int id, UserEmailDTO userEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userEmail.UserEmailID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(userEmail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEmailExists(id))
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

        // POST: api/UserEmails
        [ResponseType(typeof(UserEmailDTO))]
        public IHttpActionResult PostUserEmail(UserEmailDTO userEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(userEmail);

            return CreatedAtRoute("DefaultApi", new { id = userEmail.UserEmailID }, userEmail);
        }

        // DELETE: api/UserEmails/5
        [ResponseType(typeof(UserEmailDTO))]
        public IHttpActionResult DeleteUserEmail(int id)
        {
            var userEmail = db.Delete(id);

            return Ok(userEmail);
        }

        private bool UserEmailExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}