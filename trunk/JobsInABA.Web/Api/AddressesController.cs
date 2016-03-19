using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using JobsInABA.DAL.Entities;
using JobsInABA.Workflows;
using JobsInABA.BL.DTOs;

namespace Api.Controllers
{
    public class AddressesController : ApiController
    {
        private AddressWorkflows db = new AddressWorkflows();

        // GET: api/Addresses
        public IEnumerable<AddressDTO> GetAddresses()
        {
            return db.Get();
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(AddressDTO))]
        public IHttpActionResult GetAddress(int id)
        {
            AddressDTO address = db.Get(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, AddressDTO address)
        {
            try
            {
                db.UpdateAddress(address);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            db.CreateAddress(address);

            return CreatedAtRoute("DefaultApi", new { id = address.AddressID }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            var address = db.DeleteAddress(id);

            return Ok();
        }

        private bool AddressExists(int id)
        {
            return (db.GetAddressByID(id) != null);
        }
    }
}