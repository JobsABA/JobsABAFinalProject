using System;
using System.Collections.Generic;
using System.Linq;
using JobsInABA.DAL.Entities;
using AutoMapper;

namespace JobsInABA.DAL.Repositories
{
    public class UserAccountRepo : IDisposable
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

        public UserAccount GetUserAccountByID(Int32 Id)
        {
            UserAccount oUserAccountAccount = null;

            using (DBContext)
            {
                try
                {
                    oUserAccountAccount = DBContext.UserAccounts.FirstOrDefault(o => o.UserAccountID == Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oUserAccountAccount;
        }

        public UserAccount GetUserAccountByUserID(int UserID)
        {
            UserAccount oUserAccountAccount = null;

            using (DBContext)
            {
                try
                {
                    oUserAccountAccount = DBContext.UserAccounts.FirstOrDefault(o => o.UserID == UserID);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oUserAccountAccount;
        }

        public IEnumerable<UserAccount> GetUserAccount()
        {
            List<UserAccount> oUserAccounts = null;

            using (DBContext)
            {
                try
                {
                    var count = DBContext.Users.Count();
                    oUserAccounts = DBContext.UserAccounts.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oUserAccounts;
        }

        public UserAccount CreateUserAccount(UserAccount oUserAccount)
        {
            UserAccount oUserAccountReturn = new UserAccount();

            using (DBContext)
            {
                try
                {
                    oUserAccountReturn = DBContext.UserAccounts.Add(oUserAccount);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oUserAccountReturn;
        }

        public UserAccount UpdateUserAccount(UserAccount oUserAccount)
        {
            UserAccount oUserAccountReturn = null;
            if (oUserAccount != null && (oUserAccount.UserAccountID > 0 || oUserAccount.UserName != null))
            {
                //using (DBContext)
                //{
                JobsInABAEntities DBContext = new JobsInABAEntities();
                UserAccount u = DBContext.UserAccounts.FirstOrDefault(p => p.UserAccountID == oUserAccount.UserAccountID || p.UserName == oUserAccount.UserName);

                if (u != null)
                {
                    oUserAccount.UserAccountID = u.UserAccountID;
                    oUserAccount.IsActive = u.IsActive;
                    oUserAccount.IsDeleted = u.IsDeleted;
                    DBContext.Entry(u).CurrentValues.SetValues(oUserAccount);
                    DBContext.SaveChanges();
                    oUserAccountReturn = u;
                }
                //}
            }

            return oUserAccountReturn;
        }

        public bool DeleteUserAccount(int UserAccountID)
        {

            Boolean isDeleted = false;
            using (DBContext)
            {
                UserAccount u = this.GetUserAccountByID(UserAccountID);

                if (u != null)
                {
                    DBContext.UserAccounts.Remove(u);
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

        public bool ActivateUser(int UserID)
        {
            using (DBContext)
            {
                try
                {
                    if (DBContext.UserAccounts.Count(p => p.UserID == UserID) > 0)
                    {
                        var user = DBContext.UserAccounts.FirstOrDefault(p => p.UserID == UserID);
                        user.IsActive = true;
                        DBContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        DBContext.SaveChanges();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
