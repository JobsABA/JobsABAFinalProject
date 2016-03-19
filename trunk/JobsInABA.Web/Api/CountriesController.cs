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
    public class CountriesController : ApiController
    {
        private CountriesRepo db = new CountriesRepo();

        // GET: api/Countries
        public IEnumerable<Country> GetCountries()
        {
            return db.GetCountries();
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetCountry(int id)
        {
            Country country = db.GetCountry(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCountry(int id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.CountryID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateCountry(id, country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        [ResponseType(typeof(Country))]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateCountry(country);

            return CreatedAtRoute("DefaultApi", new { id = country.CountryID }, country);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult DeleteCountry(int id)
        {
            Country country = db.DeleteCountry(id);

            return Ok(country);
        }

        private bool CountryExists(int id)
        {
            return db.GetCountry(id) != null;
        }
    }
}