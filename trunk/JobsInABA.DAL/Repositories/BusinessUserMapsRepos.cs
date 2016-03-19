using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class BusinessUserMapsRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<BusinessUserMap> GetBusinessUserMaps()
        {
            return db.BusinessUserMaps;
        }
        //business wise usermap && owner
        public IEnumerable<BusinessUserMap> GetBusinessWiseUserOwner(int businessID)
        {
            return db.BusinessUserMaps.Where(x => x.BusinessID == businessID && x.IsOwner == true);
        }

        public BusinessUserMap GetBusinessUserMap(int id)
        {
            BusinessUserMap businessUserMap = db.BusinessUserMaps.Find(id);
            return businessUserMap;
        }

        public void UpdateBusinessUserMap(int id, BusinessUserMap businessUserMap)
        {
            db.Entry(businessUserMap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public BusinessUserMap CreateBusinessUserMap(BusinessUserMap businessUserMap)
        {
            db.BusinessUserMaps.Add(businessUserMap);
            db.SaveChanges();

            return businessUserMap;
        }

        public BusinessUserMap DeleteBusinessUserMap(int id)
        {
            BusinessUserMap businessUserMap = db.BusinessUserMaps.Find(id);
            if (businessUserMap == null)
            {
                return null;
            }

            db.BusinessUserMaps.Remove(businessUserMap);
            db.SaveChanges();

            return businessUserMap;
        }

        private bool BusinessUserMapExists(int id)
        {
            return db.BusinessUserMaps.Count(e => e.BusinessUserMapID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}