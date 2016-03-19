using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class ServicesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Service> Get()
        {
            return db.Services;
        }

        public Service Get(int id)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return null;
            }

            return service;
        }

        public void Update(int id, Service service)
        {
            db.Entry(service).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Service Create(Service service)
        {
            db.Services.Add(service);
            db.SaveChanges();

            return service;
        }

        public Service Delete(int id)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return null;
            }

            db.Services.Remove(service);
            db.SaveChanges();

            return service;
        }

        private bool ServiceExists(int id)
        {
            return db.Services.Count(e => e.ServiceID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}