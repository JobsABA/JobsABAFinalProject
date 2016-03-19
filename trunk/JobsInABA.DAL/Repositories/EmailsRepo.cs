using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JobsInABA.DAL.Entities;
using AutoMapper;

namespace JobsInABA.DAL.Repositories
{
    public class EmailsRepo : IDisposable
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

        public Email GetEmailByID(Int32 Id)
        {
            Email oEmail = null;

            using (DBContext)
            {
                try
                {
                    oEmail = DBContext.Emails.Where<Email>(o => o.EmailID == Id)
                                .Include(o => o.TypeCode)
                                .Include(o => o.TypeCode.ClassType)
                                .FirstOrDefault<Email>();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oEmail;
        }

        public IEnumerable<Email> GetEmail()
        {
            List<Email> oEmail = null;

            using (DBContext)
            {
                try
                {
                    oEmail = DBContext.Emails.ToList();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oEmail;
        }

        public Email CreateEmail(Email oEmail)
        {
            Email oEmailReturn = null;

            using (DBContext)
            {
                try
                {
                    oEmailReturn = DBContext.Emails.Add(oEmail);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oEmailReturn;
        }

        public Email UpdateEmail(Email oEmail)
        {
            Email oEmailReturn = null;
            if (oEmail != null && oEmail.EmailID > 0)
            {
                using (DBContext)
                {
                    Email u = DBContext.Emails.FirstOrDefault(p => p.EmailID == oEmail.EmailID);

                    if (u != null)
                    {
                        DBContext.Entry(u).CurrentValues.SetValues(oEmail);
                        DBContext.SaveChanges();
                        oEmailReturn = u;
                    }
                }
            }

            return oEmailReturn;
        }

        public bool DeleteEmail(int EmailID)
        {

            Boolean isDeleted = false;
            using (DBContext)
            {
                Email u = this.GetEmailByID(EmailID);

                if (u != null)
                {
                    DBContext.Emails.Remove(u);
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
