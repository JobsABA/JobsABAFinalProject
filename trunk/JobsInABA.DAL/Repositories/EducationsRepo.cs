using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class EducationsRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Education> Get()
        {
            return db.Educations.Include(p => p.User);
        }

        public Education Get(int id)
        {
            Education education = db.Educations.Include(p => p.User)
                .FirstOrDefault(p => p.EducationID == id);
            if (education == null)
            {
                return null;
            }

            return education;
        }

        public void Update(int id, Education education)
        {
            db.Entry(education).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Education Create(Education education)
        {
            db.Educations.Add(education);
            db.SaveChanges();

            return education;
        }

        public Education Delete(int id)
        {
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return null;
            }

            db.Educations.Remove(education);
            db.SaveChanges();

            return education;
        }


        private bool EducationExists(int id)
        {
            return db.Educations.Count(e => e.EducationID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}