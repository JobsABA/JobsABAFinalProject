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

namespace Api.Controllers
{
    public class TypeCodesController : ApiController
    {
        private JobsInABA.DAL.Entities.JobsInABAEntities db = new JobsInABA.DAL.Entities.JobsInABAEntities();

        // GET: api/JobsInABA.DAL.Entities.TypeCodes
        public IQueryable<JobsInABA.DAL.Entities.TypeCode> GetTypeCodes()
        {
            return db.TypeCodes;
        }

        // GET: api/JobsInABA.DAL.Entities.TypeCodes/5
        [ResponseType(typeof(JobsInABA.DAL.Entities.TypeCode))]
        public IHttpActionResult GetTypeCode(int id)
        {
            JobsInABA.DAL.Entities.TypeCode typeCode = db.TypeCodes.Find(id);
            if (typeCode == null)
            {
                return NotFound();
            }

            return Ok(typeCode);
        }

        // PUT: api/JobsInABA.DAL.Entities.TypeCodes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeCode(int id, JobsInABA.DAL.Entities.TypeCode typeCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeCode.TypeCodeID)
            {
                return BadRequest();
            }

            db.Entry(typeCode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeCodeExists(id))
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

        // POST: api/JobsInABA.DAL.Entities.TypeCodes
        [ResponseType(typeof(JobsInABA.DAL.Entities.TypeCode))]
        public IHttpActionResult PostTypeCode(JobsInABA.DAL.Entities.TypeCode typeCode)
        {
            typeCode = new JobsInABA.DAL.Entities.TypeCode();
            typeCode.ClassTypeID = 1;
            typeCode.Code = "p";
            typeCode.Description = "NA";
            typeCode.Name = "primary";
            typeCode.TypeCodeID = 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeCodes.Add(typeCode);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeCode.TypeCodeID }, typeCode);
        }

        // DELETE: api/JobsInABA.DAL.Entities.TypeCodes/5
        [ResponseType(typeof(JobsInABA.DAL.Entities.TypeCode))]
        public IHttpActionResult DeletetypeCode(int id)
        {
            JobsInABA.DAL.Entities.TypeCode typeCode = db.TypeCodes.Find(id);
            if (typeCode == null)
            {
                return NotFound();
            }

            db.TypeCodes.Remove(typeCode);
            db.SaveChanges();

            return Ok(typeCode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeCodeExists(int id)
        {
            return db.TypeCodes.Count(e => e.TypeCodeID == id) > 0;
        }
    }
}