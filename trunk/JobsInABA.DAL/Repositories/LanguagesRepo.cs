using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class LanguagesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Language> Get()
        {
            return db.Languages.Include(p => p.User);
        }

        public Language Get(int id)
        {
            Language language = db.Languages.
                Include(p => p.User).FirstOrDefault(p => p.LanguageID == id);
            if (language == null)
            {
                return null;
            }

            return language;
        }

        public void Update(int id, Language language)
        {
            db.Entry(language).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Language Create(Language language)
        {
            db.Languages.Add(language);
            db.SaveChanges();

            return language;
        }

        public Language Delete(int id)
        {
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return null;
            }

            db.Languages.Remove(language);
            db.SaveChanges();

            return language;
        }

        private bool LanguageExists(int id)
        {
            return db.Languages.Count(e => e.LanguageID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}