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
using JobsInABA.Workflows.Models;
using JobsInABA.Web.Services;
using System.Text;

namespace Api.Controllers
{
    public class UsersController : ApiController
    {
        private UserWorkflows db = new UserWorkflows();

        // GET: api/Users
        public IEnumerable<UserDataModel> GetUsers()
        {
            return db.Get();
        }

        // GET: api/Users/5
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult GetUser(int id)
        {
            UserDataModel user = db.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, UserDataModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult PostUser([FromBody]UserDataModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(user);
            EmailService.SendPasswordResetEmail(user.UserName, user.UserName);
            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult SignIn(string username, string password)
        {
            if (username == null || password == null)
                return StatusCode(HttpStatusCode.BadRequest);

            var user = db.Get().FirstOrDefault(p => p.UserName == username && p.UserAccountPassword == password);

            if (user == null)
            {
                return NotFound();
            }
            else if (user.IsActive)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok(db.Delete(id));
        }

        private bool UserExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}