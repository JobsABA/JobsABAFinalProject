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

namespace Api.Controllers
{
    public class ExperiencesController : ApiController
    {
        private ExperienceBL db = new ExperienceBL();

        // GET: api/Experiences
        public IEnumerable<ExperienceDTO> GetExperiences()
        {
            return db.Get();
        }

        // GET: api/Experiences/5
        [ResponseType(typeof(ExperienceDTO))]
        public IHttpActionResult GetExperience(int id)
        {
            ExperienceDTO experience = db.Get(id);
            if (experience == null)
            {
                return NotFound();
            }

            return Ok(experience);
        }

        // PUT: api/Experiences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExperience(int id, ExperienceDTO experience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != experience.ExperienceID)
            {
                return BadRequest();
            }

            try
            {
                db.Create(experience);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
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

        // POST: api/Experiences
        [ResponseType(typeof(ExperienceDTO))]
        public IHttpActionResult PostExperience(ExperienceDTO experience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(experience);

            return CreatedAtRoute("DefaultApi", new { id = experience.ExperienceID }, experience);
        }

        // DELETE: api/Experiences/5
        [ResponseType(typeof(Experience))]
        public IHttpActionResult DeleteExperience(int id)
        {
            ExperienceDTO experience = db.Get(id);
            if (experience == null)
            {
                return NotFound();
            }

            db.Delete(id);

            return Ok(experience);
        }

        private bool ExperienceExists(int id)
        {
            return db.Get(id)!=null;
        }
    }
}