using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JobsInABA.DAL.Entities;
using AutoMapper;

namespace JobsInABA.DAL.Repositories
{
    public class PhonesRepo : IDisposable
    {
        JobsInABAEntities _DBContext;
        private JobsInABAEntities DBContext
        {
            get
            {
                if (_DBContext == null) _DBContext = new JobsInABAEntities();

                return _DBContext;
            }
        }

        public Phone GetPhoneByID(Int32 Id)
        {
            Phone oPhone = null;

            using (DBContext)
            {
                try
                {
                    oPhone = DBContext.Phones.Where<Phone>(o => o.PhoneID == Id)
                                .Include(o => o.TypeCode)
                                .Include(o => o.TypeCode.ClassType)
                                .FirstOrDefault<Phone>();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oPhone;
        }

        public IEnumerable<Phone> GetPhone()
        {
            List<Phone> oPhone = null;

            using (DBContext)
            {
                try
                {
                    oPhone = DBContext.Phones.ToList();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oPhone;
        }

        public Phone CreatePhone(Phone oPhone)
        {
            Phone oPhoneReturn = null;

            using (DBContext)
            {
                try
                {
                    oPhoneReturn = DBContext.Phones.Add(oPhone);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oPhoneReturn;
        }

        public Phone UpdatePhone(Phone oPhone)
        {
            Phone oPhoneReturn = null;
            if (oPhone != null && oPhone.PhoneID > 0)
            {
                using (DBContext)
                {
                    Phone u = DBContext.Phones.FirstOrDefault(p => p.PhoneID == oPhone.PhoneID);

                    if (u != null)
                    {
                        DBContext.Entry(u).CurrentValues.SetValues(oPhone);
                        DBContext.SaveChanges();
                        oPhoneReturn = u;
                    }
                }
            }

            return oPhoneReturn;
        }

        public bool DeletePhone(int PhoneID)
        {

            Boolean isDeleted = false;
            using (DBContext)
            {
                Phone u = this.GetPhoneByID(PhoneID);

                if (u != null)
                {
                    DBContext.Phones.Remove(u);
                    DBContext.SaveChanges();
                    isDeleted = true;
                }
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _DBContext.Dispose();
        }
    }
}
