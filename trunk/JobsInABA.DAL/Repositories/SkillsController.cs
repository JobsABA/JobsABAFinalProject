using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class SkillsRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Skill> Get()
        {
            return db.Skills;
        }

        public Skill Get(int id)
        {
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return null;
            }

            return skill;
        }

        public void Update(int id, Skill skill)
        {
            db.Entry(skill).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Skill Create(Skill skill)
        {
            db.Skills.Add(skill);
            db.SaveChanges();

            return skill;
        }

        public Skill Delete(int id)
        {
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return null;
            }

            db.Skills.Remove(skill);
            db.SaveChanges();

            return skill;
        }

        private bool SkillExists(int id)
        {
            return db.Skills.Count(e => e.SkillID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}