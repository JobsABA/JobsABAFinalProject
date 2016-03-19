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

        // GET: api/Skills/5
        [ResponseType(typeof(Skill))]
        public IHttpActionResult GetSkill(int id)
        {
            SkillDTO  skill = db.Get(id);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(skill);
            
            return CreatedAtRoute("DefaultApi", new { id = skill.SkillID }, skill);
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
            return db.Get(id)!=null;
        }
    }
}