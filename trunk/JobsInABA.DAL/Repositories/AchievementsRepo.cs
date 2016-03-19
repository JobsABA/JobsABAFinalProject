using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class AchievementsRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Achievement> Get()
        {
            return db.Achievements.Include(p => p.User);
        }

        public Achievement Get(int id)
        {
            Achievement achievement = db.Achievements.Include(p => p.User)
                .FirstOrDefault(p => p.AchievementID == id);
            return achievement;
        }

        public void Update(int id, Achievement achievement)
        {
            db.Entry(achievement).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Achievement Create(Achievement achievement)
        {
            db.Achievements.Add(achievement);
            db.SaveChanges();

            return achievement;
        }

        public Achievement Delete(int id)
        {
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return null;
            }

            db.Achievements.Remove(achievement);
            db.SaveChanges();

            return achievement;
        }

        private bool AchievementExists(int id)
        {
            return db.Achievements.Count(e => e.AchievementID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}