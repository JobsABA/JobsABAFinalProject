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
    public class UserAddressesController : ApiController
    {
        private UserAddressesWorkflows db = new UserAddressesWorkflows();

        // GET: api/UserAddresses
        public IEnumerable<UserAddressDTO> GetUserAddresses()
        {
            return db.Get();
        }

        // GET: api/UserAddresses/5
        [ResponseType(typeof(UserAddressDTO))]
        public IHttpActionResult GetUserAddress(int id)
        {
            UserAddressDTO userAddress = new UserAddressDTO();
            userAddress = db.Get(id);
            if (userAddress == null)
            {
                return NotFound();
            }

            return Ok(userAddress);
        }

        // PUT: api/UserAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAddress(int id, UserAddressDTO userAddress)
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
                db.Update(userAddress);
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
        public IHttpActionResult PostUserAddress(UserAddressDTO userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(userAddress);

            return CreatedAtRoute("DefaultApi", new { id = userAddress.UserAddressID }, userAddress);
        }

        // DELETE: api/UserAddresses/5
        [ResponseType(typeof(UserAddressDTO))]
        public IHttpActionResult DeleteUserAddress(int id)
        {
            var userAddress = db.Delete(id);

            return Ok(userAddress);
        }

        private bool UserAddressExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}