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
    public class AchievementsController : ApiController
    {
        private AchievementBL db = new AchievementBL();

        // GET: api/Achievements
        public IEnumerable<AchievementDTO> GetAchievements()
        {
            return db.Get();
        }

        // GET: api/Achievements/5
        [ResponseType(typeof(AchievementDTO))]
        public IHttpActionResult GetAchievement(int id)
        {
            AchievementDTO achievement = db.Get(id);
            if (achievement == null)
            {
                return NotFound();
            }

            return Ok(achievement);
        }

        // PUT: api/Achievements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAchievement(int id, AchievementDTO achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != achievement.AchievementID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(achievement);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementExists(id))
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

        // POST: api/Achievements
        [ResponseType(typeof(AchievementDTO))]
        public IHttpActionResult PostAchievement(AchievementDTO achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(achievement);

            return CreatedAtRoute("DefaultApi", new { id = achievement.AchievementID }, achievement);
        }

        // DELETE: api/Achievements/5
        [ResponseType(typeof(AchievementDTO))]
        public IHttpActionResult DeleteAchievement(int id)
        {
            AchievementDTO achievement = db.Get(id);
            if (achievement == null)
            {
                return NotFound();
            }

            db.Create(achievement);

            return Ok(achievement);
        }

        private bool AchievementExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}