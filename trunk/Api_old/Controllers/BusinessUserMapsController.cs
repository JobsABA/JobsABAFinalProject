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

namespace Api.Controllers
{
    public class BusinessUserMapsController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/BusinessUserMaps
        public IQueryable<BusinessUserMap> GetBusinessUserMaps()
        {
            return db.BusinessUserMaps;
        }

        // GET: api/BusinessUserMaps/5
        [ResponseType(typeof(BusinessUserMap))]
        public IHttpActionResult GetBusinessUserMap(int id)
        {
            BusinessUserMap businessUserMap = db.BusinessUserMaps.Find(id);
            if (businessUserMap == null)
            {
                return NotFound();
            }

            return Ok(businessUserMap);
        }

        // PUT: api/BusinessUserMaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusinessUserMap(int id, BusinessUserMap businessUserMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessUserMap.BusinessUserMapID)
            {
                return BadRequest();
            }

            db.Entry(businessUserMap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessUserMapExists(id))
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

        // POST: api/BusinessUserMaps
        [ResponseType(typeof(BusinessUserMap))]
        public IHttpActionResult PostBusinessUserMap(BusinessUserMap businessUserMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BusinessUserMaps.Add(businessUserMap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = businessUserMap.BusinessUserMapID }, businessUserMap);
        }

        // DELETE: api/BusinessUserMaps/5
        [ResponseType(typeof(BusinessUserMap))]
        public IHttpActionResult DeleteBusinessUserMap(int id)
        {
            BusinessUserMap businessUserMap = db.BusinessUserMaps.Find(id);
            if (businessUserMap == null)
            {
                return NotFound();
            }

            db.BusinessUserMaps.Remove(businessUserMap);
            db.SaveChanges();

            return Ok(businessUserMap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessUserMapExists(int id)
        {
            return db.BusinessUserMaps.Count(e => e.BusinessUserMapID == id) > 0;
        }
    }
}