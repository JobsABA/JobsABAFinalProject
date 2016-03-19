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
using JobsInABA.BL;
using JobsInABA.BL.DTOs;

namespace JobsInABA.Web.Api
{
    public class ServicesController : ApiController
    {
        private ServiceBL db = new ServiceBL();

        // GET: api/Services
        public IEnumerable<ServiceDTO> GetServices()
        {
            return db.Get();
        }

        // GET: api/Services/5
        [ResponseType(typeof(ServiceDTO))]
        public IHttpActionResult GetService(int id)
        {
            ServiceDTO service = db.Get(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // PUT: api/Services/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutService(int id, ServiceDTO service)
        {
            //service = new ServiceDTO();
            //service.Name = "Modi Services";
            //service.BusinessID = 18;
            //service.ServiceID = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != service.ServiceID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(service);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Services
        [ResponseType(typeof(ServiceDTO))]
        public IHttpActionResult PostService(ServiceDTO service)
        {
            //service = new ServiceDTO();
            //service.Name = "New Services";
            //service.BusinessID = 18;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objService = db.Create(service);

            return CreatedAtRoute("DefaultApi", new { id = service.ServiceID }, objService);
        }

        // DELETE: api/Services/5
        [ResponseType(typeof(ServiceDTO))]
        public IHttpActionResult DeleteService(int id)
        {
            ServiceDTO service = db.Get(id);
            if (service == null)
            {
                return NotFound();
            }

            db.Delete(id);

            return Ok(service);
        }

        private bool ServiceExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}