using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class UserEmailsRepo:IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<UserEmail> GetUserEmails()
        {
            return db.UserEmails;
        }

        public UserEmail GetUserEmail(int id)
        {
            UserEmail userEmail = db.UserEmails.Find(id);
            return userEmail;
        }

        public void UpdateUserEmail(int id, UserEmail userEmail)
        {
            var user = db.UserEmails.FirstOrDefault(p => p.EmailID == id);
            user = userEmail;
            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public UserEmail CreateUserEmail(UserEmail userEmail)
        {
            db.UserEmails.Add(userEmail);
            db.SaveChanges();

            return userEmail;
        }

        public UserEmail DeleteUserEmail(int id)
        {
            UserEmail userEmail = db.UserEmails.Find(id);
            if (userEmail == null)
            {
                return null;
            }

            db.UserEmails.Remove(userEmail);
            db.SaveChanges();

            return userEmail;
        }

        private bool UserEmailExists(int id)
        {
            return db.UserEmails.Count(e => e.UserEmailID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}