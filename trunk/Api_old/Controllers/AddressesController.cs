using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using JobsInABA.DAL.Entities;
using JobsInABA.Workflows;
using JobsInABA.BL;
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
            //address = new AddressDTO();
            //address.AddressID = id;
            //address.Title = "Primary Address";
            //address.Line1 = "ModiAddress Line 1";
            //address.Line2 = "NoLine";
            //address.Line3 = "Address Line 3";
            //address.City = "Surat";
            //address.State = "Gujarat";
            //address.ZipCode = "360001";
            //address.CountryID = 2;
            //address.AddressTypeID = 7;
            try
            {
                db.Update(address);
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
        [ResponseType(typeof(AddressDTO))]
        public IHttpActionResult PostAddress(AddressDTO address)
        {
            var objAddress = db.Create(address);

            return CreatedAtRoute("DefaultApi", new { id = address.AddressID }, objAddress);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(AddressDTO))]
        public IHttpActionResult DeleteAddress(int id)
        {
            var address = db.Delete(id);

            return Ok();
        }

        private bool AddressExists(int id)
        {
            return (db.Get(id) != null);
        }
    }
}