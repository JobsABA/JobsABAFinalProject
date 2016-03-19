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
    public class SkillsController : ApiController
    {
        private SkillBL db = new SkillBL();

        // GET: api/Skills
        public IEnumerable<SkillDTO> GetSkills()
        {
            return db.Get();
        }

        public IEnumerable<SkillDTO> GetSkillsByUserID(int id)
        {
            return db.Get().Where(p => p.UserID == id);
        }

        // GET: api/Skills/5
        [ResponseType(typeof(Skill))]
        public IHttpActionResult GetSkill(int id)
        {
            SkillDTO skill = db.Get(id);
            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        // PUT: api/Skills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkill(int id, SkillDTO skill)
        {
            //skill = new SkillDTO();
            //skill.Skill1 = "Skill2 Mod";
            //skill.UserID = 50;
            //skill.SkillID = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skill.SkillID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(skill);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST: api/Skills
        [ResponseType(typeof(SkillDTO))]
        public IHttpActionResult PostSkill(SkillDTO skill)
        {
            //skill = new SkillDTO();
            //skill.Skill1 = "Skill 2";
            //skill.UserID = 50;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objSkill = db.Create(skill);

            return CreatedAtRoute("DefaultApi", new { id = skill.SkillID }, objSkill);
        }

        // DELETE: api/Skills/5
        [ResponseType(typeof(SkillDTO))]
        public IHttpActionResult DeleteSkill(int id)
        {
            SkillDTO skill = db.Get(id);
            if (skill == null)
            {
                return NotFound();
            }

            db.Delete(id);

            return Ok(skill);
        }

        private bool SkillExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}