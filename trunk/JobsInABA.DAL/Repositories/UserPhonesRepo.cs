using JobsInABA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace JobsInABA.DAL.Repositories
{
    public class UserPhonesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<UserPhone> GetUserPhones()
        {
            return db.UserPhones;
        }

        public UserPhone GetUserPhone(int id)
        {
            UserPhone userPhone = db.UserPhones.Find(id);
            return userPhone;
        }

        public void UpdateUserPhone(int id, UserPhone userPhone)
        {
            var user = db.UserPhones.FirstOrDefault(p => p.UserID == id);
            user = userPhone;
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

        public UserPhone CreateUserPhone(UserPhone userPhone)
        {
            db.UserPhones.Add(userPhone);
            db.SaveChanges();

            return userPhone;
        }

        public UserPhone DeleteUserPhone(int id)
        {
            UserPhone userPhone = db.UserPhones.Find(id);
            if (userPhone == null)
            {
                return null;
            }

            db.UserPhones.Remove(userPhone);
            db.SaveChanges();

            return userPhone;
        }

        private bool UserPhoneExists(int id)
        {
            return db.UserPhones.Count(e => e.UserPhoneID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}