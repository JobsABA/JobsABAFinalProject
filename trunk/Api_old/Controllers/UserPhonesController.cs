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
    public class UserPhonesController : ApiController
    {
        private UserPhonesWorkflows db = new UserPhonesWorkflows();

        // GET: api/UserPhones
        public IEnumerable<UserPhoneDTO> GetUserPhones()
        {
            return db.Get();
        }

        // GET: api/UserPhones/5
        [ResponseType(typeof(UserPhoneDTO))]
        public IHttpActionResult GetUserPhone(int id)
        {
            UserPhoneDTO userPhone = db.Get(id);
            if (userPhone == null)
            {
                return NotFound();
            }

            return Ok(userPhone);
        }

        // PUT: api/UserPhones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserPhone(int id, UserPhoneDTO userPhone)
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
                db.Update(userPhone);
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
        [ResponseType(typeof(UserPhoneDTO))]
        public IHttpActionResult PostUserPhone(UserPhoneDTO userPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(userPhone);

            return CreatedAtRoute("DefaultApi", new { id = userPhone.UserPhoneID }, userPhone);
        }

        // DELETE: api/UserPhones/5
        [ResponseType(typeof(UserPhoneDTO))]
        public IHttpActionResult DeleteUserPhone(int id)
        {
            var userPhone = db.Delete(id);

            return Ok(userPhone);
        }

        private bool UserPhoneExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}