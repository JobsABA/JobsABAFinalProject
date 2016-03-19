using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class ImagesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Image> Get()
        {
            return db.Images;
        }

        public Image Get(int id)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return null;
            }

            return image;
        }

        public void Update(int id, Image image)
        {
            db.Entry(image).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Image Create(Image image)
        {
            db.Images.Add(image);
            db.SaveChanges();

            return image;
        }

        public Image Delete(int id)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return null;
            }

            db.Images.Remove(image);
            db.SaveChanges();

            return image;
        }

        private bool ImageExists(int id)
        {
            return db.Images.Count(e => e.ImageID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}