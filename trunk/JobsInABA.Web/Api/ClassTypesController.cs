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
    public class ClassTypesController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/ClassTypes
        public IQueryable<ClassType> GetClassTypes()
        {
            return db.ClassTypes;
        }

        // GET: api/ClassTypes/5
        [ResponseType(typeof(ClassType))]
        public IHttpActionResult GetClassType(int id)
        {
            ClassType classType = db.ClassTypes.Find(id);
            if (classType == null)
            {
                return NotFound();
            }

            return Ok(classType);
        }

        // PUT: api/ClassTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClassType(int id, ClassType classType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classType.ClassTypeID)
            {
                return BadRequest();
            }

            db.Entry(classType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassTypeExists(id))
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

        // POST: api/ClassTypes
        [ResponseType(typeof(ClassType))]
        public IHttpActionResult PostClassType(ClassType classType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClassTypes.Add(classType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = classType.ClassTypeID }, classType);
        }

        // DELETE: api/ClassTypes/5
        [ResponseType(typeof(ClassType))]
        public IHttpActionResult DeleteClassType(int id)
        {
            ClassType classType = db.ClassTypes.Find(id);
            if (classType == null)
            {
                return NotFound();
            }

            db.ClassTypes.Remove(classType);
            db.SaveChanges();

            return Ok(classType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassTypeExists(int id)
        {
            return db.ClassTypes.Count(e => e.ClassTypeID == id) > 0;
        }
    }
}