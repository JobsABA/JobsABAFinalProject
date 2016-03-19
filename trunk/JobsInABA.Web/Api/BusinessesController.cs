using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using JobsInABA.Workflows;
using JobsInABA.Workflows.Models;
using System;

namespace Api.Controllers
{
    public class BusinessesController : ApiController
    {
        private BusinessWorkflows db = new BusinessWorkflows();

        // GET: api/Businesses
        public List<BusinessDataModel> GetBusinesses()
        {
            return db.Get();
        }

        // GET: api/Businesses/5
        [ResponseType(typeof(BusinessDataModel))]
        public IHttpActionResult GetBusiness(int id)
        {
            BusinessDataModel BusinessDataModel = db.Get(id);
            if (BusinessDataModel == null)
            {
                return NotFound();
            }

            return Ok(BusinessDataModel);
        }

        // PUT: api/Businesses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusiness(int id, BusinessDataModel business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != business.BusinessID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(business);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        // POST: api/Businesses
        [ResponseType(typeof(BusinessDataModel))]
        public IHttpActionResult PostBusiness(BusinessDataModel business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(business);

            return CreatedAtRoute("DefaultApi", new { id = business.BusinessID }, business);
        }

        // DELETE: api/Businesses/5
        [ResponseType(typeof(BusinessDataModel))]
        public IHttpActionResult DeleteBusiness(int id)
        {
            var business = db.Delete(id);

            return Ok(business);
        }

        private bool BusinessExists(int id)
        {
            return (db.Get(id) != null);
        }
    }
}