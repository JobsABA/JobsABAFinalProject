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
    public class PhonesController : ApiController
    {
        private PhonesRepo db = new PhonesRepo();

        // GET: api/Phones
        public IEnumerable<Phone> GetPhones()
        {
            return db.GetPhone();
        }

        // GET: api/Phones/5
        [ResponseType(typeof(Phone))]
        public IHttpActionResult GetPhone(int id)
        {
            Phone phone = db.GetPhoneByID(id);
            if (phone == null)
            {
                return NotFound();
            }

            return Ok(phone);
        }

        // PUT: api/Phones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhone(int id, Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phone.PhoneID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdatePhone(phone);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
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

        // POST: api/Phones
        [ResponseType(typeof(Phone))]
        public IHttpActionResult PostPhone(Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreatePhone(phone);

            return CreatedAtRoute("DefaultApi", new { id = phone.PhoneID }, phone);
        }

        // DELETE: api/Phones/5
        [ResponseType(typeof(Phone))]
        public IHttpActionResult DeletePhone(int id)
        {
            var phone = db.DeletePhone(id);

            return Ok(phone);
        }

        private bool PhoneExists(int id)
        {
            return db.GetPhoneByID(id) != null;
        }
    }
}