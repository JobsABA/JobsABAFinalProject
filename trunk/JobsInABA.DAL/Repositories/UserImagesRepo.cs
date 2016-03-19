using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class UserImagesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<UserImage> Get()
        {
            return db.UserImages;
        }

        public UserImage Get(int id)
        {
            UserImage userImage = db.UserImages.Find(id);
            if (userImage == null)
            {
                return null;
            }

            return userImage;
        }

        public void Update(int id, UserImage userImage)
        {
            db.Entry(userImage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public UserImage Create(UserImage userImage)
        {

            db.UserImages.Add(userImage);
            db.SaveChanges();

            return userImage;
        }

        public UserImage Delete(int id)
        {
            UserImage userImage = db.UserImages.Find(id);
            if (userImage == null)
            {
                return null;
            }

            db.UserImages.Remove(userImage);
            db.SaveChanges();

            return userImage;
        }

        public bool UserImageExists(int id)
        {
            return db.UserImages.Count(e => e.UserImageID == id) > 0;
        }

        public bool UserPrimaryImageExists(int id)
        {
            return db.UserImages.Count(e => e.UserID == id && e.IsPrimary==true) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}