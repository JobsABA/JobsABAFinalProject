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

        public IEnumerable<ExperienceDTO> GetExperiencesByUserID(int id)
        {
            return db.Get().Where(p => p.UserID == id);
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
            //experience = new ExperienceDTO();
            //experience.BusinessID = 18;
            //experience.JobPossition = "S SD";
            //experience.UserID = 50;
            //experience.ExperienceID = id;

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
                db.Update(experience);
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
            //experience = new ExperienceDTO();
            //experience.BusinessID = 18;
            //experience.JobPossition = "Software Developer";
            //experience.UserID = 50;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objExprience = db.Create(experience);

            return CreatedAtRoute("DefaultApi", new { id = experience.ExperienceID }, objExprience);
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
            return db.Get(id) != null;
        }
    }
}