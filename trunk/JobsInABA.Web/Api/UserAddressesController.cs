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
    public class UserAddressesController : ApiController
    {
        private UserAddressesRepo db = new UserAddressesRepo();

        // GET: api/UserAddresses
        public IEnumerable<UserAddress> GetUserAddresses()
        {
            return db.GetUserAddresses();
        }

        // GET: api/UserAddresses/5
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult GetUserAddress(int id)
        {
            UserAddress userAddress = db.GetUserAddress(id);
            if (userAddress == null)
            {
                return NotFound();
            }

            return Ok(userAddress);
        }

        // PUT: api/UserAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAddress(int id, UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAddress.UserAddressID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateUserAddress(id,userAddress);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressExists(id))
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

        // POST: api/UserAddresses
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult PostUserAddress(UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateUserAddress(userAddress);

            return CreatedAtRoute("DefaultApi", new { id = userAddress.UserAddressID }, userAddress);
        }

        // DELETE: api/UserAddresses/5
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult DeleteUserAddress(int id)
        {
            var userAddress = db.DeleteUserAddress(id);

            return Ok(userAddress);
        }

        private bool UserAddressExists(int id)
        {
            return db.GetUserAddress(id) != null;
        }
    }
}