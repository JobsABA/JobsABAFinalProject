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
    public class UserPhonesController : ApiController
    {
        private UserPhonesRepo db = new UserPhonesRepo();

        // GET: api/UserPhones
        public IEnumerable<UserPhone> GetUserPhones()
        {
            return db.GetUserPhones();
        }

        // GET: api/UserPhones/5
        [ResponseType(typeof(UserPhone))]
        public IHttpActionResult GetUserPhone(int id)
        {
            UserPhone userPhone = db.GetUserPhone(id);
            if (userPhone == null)
            {
                return NotFound();
            }

            return Ok(userPhone);
        }

        // PUT: api/UserPhones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserPhone(int id, UserPhone userPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userPhone.UserPhoneID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateUserPhone(id, userPhone);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPhoneExists(id))
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

        // POST: api/UserPhones
        [ResponseType(typeof(UserPhone))]
        public IHttpActionResult PostUserPhone(UserPhone userPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateUserPhone(userPhone);

            return CreatedAtRoute("DefaultApi", new { id = userPhone.UserPhoneID }, userPhone);
        }

        // DELETE: api/UserPhones/5
        [ResponseType(typeof(UserPhone))]
        public IHttpActionResult DeleteUserPhone(int id)
        {
            var userPhone = db.DeleteUserPhone(id);

            return Ok(userPhone);
        }

        private bool UserPhoneExists(int id)
        {
            return db.GetUserPhone(id) != null;
        }
    }
}