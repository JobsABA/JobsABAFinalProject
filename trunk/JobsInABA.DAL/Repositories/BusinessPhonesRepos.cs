using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class BusinessPhonesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<BusinessPhone> GetBusinessPhones()
        {
            return db.BusinessPhones;
        }

        public BusinessPhone GetBusinessPhone(int id)
        {
            BusinessPhone businessPhone = db.BusinessPhones.Find(id);
            return businessPhone;
        }

        public void UpdateBusinessPhone(int id, BusinessPhone businessPhone)
        {
            db.Entry(businessPhone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public BusinessPhone CreateBusinessPhone(BusinessPhone businessPhone)
        {
            db.BusinessPhones.Add(businessPhone);
            db.SaveChanges();

            return businessPhone;
        }

        public BusinessPhone DeleteBusinessPhone(int id)
        {
            BusinessPhone businessPhone = db.BusinessPhones.Find(id);
            if (businessPhone == null)
            {
                return null;
            }

            db.BusinessPhones.Remove(businessPhone);
            db.SaveChanges();

            return businessPhone;
        }

        private bool BusinessPhoneExists(int id)
        {
            return db.BusinessPhones.Count(e => e.BusinessPhoneID == id) > 0;
        }
        
        protected void Dispose()
        {
            db.Dispose();
        }

        void IDisposable.Dispose()
        {
            db.Dispose();
        }
    }
}