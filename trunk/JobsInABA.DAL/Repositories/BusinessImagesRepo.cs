using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class BusinessImagesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<BusinessImage> Get()
        {
            return db.BusinessImages.Include(p => p.Image);
        }

        public BusinessImage Get(int id)
        {
            BusinessImage businessImage = db.BusinessImages.Include(p => p.Image).FirstOrDefault(p => p.BusinessImageID == id);
            if (businessImage == null)
            {
                return null;
            }

            return businessImage;
        }

        public void Update(int id, BusinessImage businessImage)
        {
            db.Entry(businessImage).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public BusinessImage Create(BusinessImage businessImage)
        {
            db.BusinessImages.Add(businessImage);
            db.SaveChanges();

            return businessImage;
        }

        public BusinessImage Delete(int id)
        {
            BusinessImage businessImage = db.BusinessImages.Find(id);
            if (businessImage == null)
            {
                return null;
            }

            db.BusinessImages.Remove(businessImage);
            db.SaveChanges();

            return businessImage;
        }

        private bool BusinessImageExists(int id)
        {
            return db.BusinessImages.Count(e => e.BusinessImageID == id) > 0;
        }

        public bool BusinessPrimaryImageExists(int id)
        {
            return db.BusinessImages.Count(e => e.BusinessID == id && e.IsPrimary == true) > 0;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}