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
using JobsInABA.Workflows;

namespace Api.Controllers
{
    public class AchievementsController : ApiController
    {
        private AchievementsWorkflows db = new AchievementsWorkflows();

        // GET: api/Achievements
        public IEnumerable<AchievementDTO> GetAchievements()
        {
            return db.Get();
        }

        public IEnumerable<AchievementDTO> GetAchievementsByUserID(int id)
        {
            return db.Get().Where(p=>p.UserID==id);
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
            //achievement = new AchievementDTO();
            //achievement.Date = DateTime.Now;
            //achievement.Name = "achi 1 mod";
            //achievement.UserID = 42;
            //achievement.AchievementID = id;

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
            //achievement = new AchievementDTO();
            //achievement.Date = DateTime.Now;
            //achievement.Name = "My Business 2 achievement 2";
            //achievement.BusinessID = 27;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objAchievement = db.Create(achievement);

            return CreatedAtRoute("DefaultApi", new { id = achievement.AchievementID }, objAchievement);
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

            db.Delete(id);

            return Ok(achievement);
        }

        private bool AchievementExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}