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
using JobsInABA.BL.DTOs;
using JobsInABA.BL;

namespace Api.Controllers
{
    public class EducationsController : ApiController
    {
        private EducationBL db = new EducationBL();

        // GET: api/Educations
        public IEnumerable<EducationDTO> GetEducations()
        {
            return db.Get();
        }

        public IEnumerable<EducationDTO> GetEducationsByUserID(int id)
        {
            return db.Get().Where(p => p.UserID == id);
        }

        // GET: api/Educations/5
        [ResponseType(typeof(EducationDTO))]
        public IHttpActionResult GetEducation(int id)
        {
            EducationDTO education = db.Get(id);
            if (education == null)
            {
                return NotFound();
            }

            return Ok(education);
        }

        // PUT: api/Educations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEducation(int id, EducationDTO education)
        {
            //education = new EducationDTO();
            //education.Degree = "BE CS";
            //education.Description = "na";
            //education.InstituteName = "inst";
            //education.IsActive = true;
            //education.EducationID = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != education.EducationID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(education);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
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

        // POST: api/Educations
        [ResponseType(typeof(EducationDTO))]
        public IHttpActionResult PostEducation(EducationDTO education)
        {
            //education = new EducationDTO();
            //education.Degree = "be";
            //education.Description = "na";
            //education.InstituteName = "inst";
            //education.IsActive = true;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objEducation = db.Create(education);

            return CreatedAtRoute("DefaultApi", new { id = education.EducationID }, objEducation);
        }

        // DELETE: api/Educations/5
        [ResponseType(typeof(EducationDTO))]
        public IHttpActionResult DeleteEducation(int id)
        {
            EducationDTO education = db.Get(id);
            if (education == null)
            {
                return NotFound();
            }

            db.Delete(id);

            return Ok(education);
        }

        private bool EducationExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}