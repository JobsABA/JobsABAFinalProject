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
    public class UserEmailsController : ApiController
    {
        private UserEmailsRepo db = new UserEmailsRepo();

        // GET: api/UserEmails
        public IEnumerable<UserEmail> GetUserEmails()
        {
            return db.GetUserEmails();
        }

        // GET: api/UserEmails/5
        [ResponseType(typeof(UserEmail))]
        public IHttpActionResult GetUserEmail(int id)
        {
            UserEmail userEmail = db.GetUserEmail(id);
            if (userEmail == null)
            {
                return NotFound();
            }

            return Ok(userEmail);
        }

        // PUT: api/UserEmails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserEmail(int id, UserEmail userEmail)
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
                db.UpdateUserEmail(id, userEmail);
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
        [ResponseType(typeof(UserEmail))]
        public IHttpActionResult PostUserEmail(UserEmail userEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateUserEmail(userEmail);

            return CreatedAtRoute("DefaultApi", new { id = userEmail.UserEmailID }, userEmail);
        }

        // DELETE: api/UserEmails/5
        [ResponseType(typeof(UserEmail))]
        public IHttpActionResult DeleteUserEmail(int id)
        {
            var userEmail = db.DeleteUserEmail(id);

            return Ok(userEmail);
        }

        private bool UserEmailExists(int id)
        {
            return db.GetUserEmail(id) != null;
        }
    }
}