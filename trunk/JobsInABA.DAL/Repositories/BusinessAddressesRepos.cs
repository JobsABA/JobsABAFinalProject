using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class BusinessAddressesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<BusinessAddress> GetBusinessAddresses()
        {
            return db.BusinessAddresses.Include(p => p.Address);
        }

        public BusinessAddress GetBusinessAddress(int id)
        {
            BusinessAddress businessAddress = db.BusinessAddresses.Include(p => p.Address).FirstOrDefault(p => p.BusinessAddressID == id);
            return businessAddress;
        }

        public void UpdateBusinessAddress(int id, BusinessAddress businessAddress)
        {
            db.Entry(businessAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public BusinessAddress CreateBusinessAddress(BusinessAddress businessAddress)
        {
            db.BusinessAddresses.Add(businessAddress);
            db.SaveChanges();

            return businessAddress;
        }

        public BusinessAddress DeleteBusinessAddress(int id)
        {
            BusinessAddress businessAddress = db.BusinessAddresses.Find(id);
            if (businessAddress == null)
            {
                return null;
            }

            db.BusinessAddresses.Remove(businessAddress);
            db.SaveChanges();

            return businessAddress;
        }

        private bool BusinessAddressExists(int id)
        {
            return db.BusinessAddresses.Count(e => e.BusinessAddressID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}