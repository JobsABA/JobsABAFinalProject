using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class ExperiencesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Experience> Get()
        {
            return db.Experiences.Include(p => p.User);
        }

        public Experience Get(int id)
        {
            Experience experience = db.Experiences.Include(p => p.User)
                .FirstOrDefault(p => p.ExperienceID == id);
            if (experience == null)
            {
                return null;
            }

            return experience;
        }

        public void Update(int id, Experience experience)
        {
            db.Entry(experience).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Experience Create(Experience experience)
        {
            db.Experiences.Add(experience);
            db.SaveChanges();

            return experience;
        }

        public Experience Delete(int id)
        {
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return null;
            }

            db.Experiences.Remove(experience);
            db.SaveChanges();

            return experience;
        }

        private bool ExperienceExists(int id)
        {
            return db.Experiences.Count(e => e.ExperienceID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}