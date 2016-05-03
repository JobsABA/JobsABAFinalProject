using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JobsInABA.DAL.Entities;
using AutoMapper;
using System.Text;

namespace JobsInABA.DAL.Repositories
{
    public class UsersRepo : IDisposable
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

        public User GetUserByID(int Id)
        {
            User model = new User();

            using (DBContext)
            {
                try
                {
                    model = DBContext.Users
                                .Include(o => o.UserAddresses
                                            .Select(ua => ua.Address)
                                            .Select(ad => ad.TypeCode)
                                            .Select(typ => typ.ClassType)
                                )
                                .Include(o => o.UserAddresses
                                                .Select(ua => ua.Address)
                                                .Select(ad => ad.Country)
                                )
                                .Include(o => o.UserEmails
                                                .Select(ue => ue.Email)
                                                .Select(e => e.TypeCode)
                                                .Select(typ => typ.ClassType)
                                )
                                .Include(o => o.UserPhones
                                                .Select(up => up.Phone)
                                                .Select(p => p.TypeCode)
                                                .Select(typ => typ.ClassType)
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.BusinessAddresses.Select(p => p.Address))
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.BusinessEmails.Select(p => p.Email))
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.BusinessImages.Select(p => p.Image))
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.Achievements)
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.BusinessPhones.Select(p => p.Phone))
                                )
                                .Include(o => o.Achievements)
                                .Include(o => o.Educations)
                                .Include(o => o.Skills)
                                .Include(o => o.Languages)
                                .Include(o => o.UserImages
                                    .Select(up => up.Image)
                                )
                            .FirstOrDefault(o => o.UserID == Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return model;
        }

        public int? CanLogIn(string username, string password)
        {
            int? returnVar = null;
            using (_DBContext)
            {
                try
                {
                    var passwordInByteArray = Encoding.ASCII.GetBytes(password);
                    //var userAccount = DBContext.UserAccounts.
                    //    FirstOrDefault(p => p.UserName == username && p.Password == passwordInByteArray && p.IsActive == true && p.IsDeleted == false);
                    var userAccount = (from a in DBContext.Emails
                                       where a.Address == username
                                       join b in DBContext.UserEmails on a.EmailID equals b.EmailID
                                       join c in DBContext.UserAccounts on b.UserID equals c.UserID
                                       where b.IsPrimary == true && c.Password == passwordInByteArray && c.IsActive == true
                                       select c).FirstOrDefault();
                    if (userAccount != null)
                    {
                        returnVar = userAccount.UserID;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return returnVar;
        }

        public IEnumerable<User> GetUsersBySearch(string searchText, int from, int to)
        {
            List<User> model = null;

            using (DBContext)
            {
                try
                {
                    model = DBContext.Users.Include(o => o.UserAddresses
                            .Select(ua => ua.Address).Select(ad => ad.TypeCode).Select(typ => typ.ClassType))
                            .Include(o => o.UserAddresses.Select(ua => ua.Address).Select(ad => ad.Country))
                                .Include(o => o.UserEmails.Select(ue => ue.Email).Select(e => e.TypeCode).Select(typ => typ.ClassType))
                                .Include(o => o.UserPhones.Select(up => up.Phone).Select(p => p.TypeCode).Select(typ => typ.ClassType))
                                .Include(o => o.Experiences.Select(ub => ub.Business).Select(ex => ex.BusinessAddresses.Select(p => p.Address)))
                                .Include(o => o.Experiences.Select(ub => ub.Business).Select(ex => ex.BusinessEmails.Select(p => p.Email)))
                                .Include(o => o.Experiences.Select(ub => ub.Business).Select(ex => ex.BusinessImages.Select(p => p.Image)))
                                .Include(o => o.Experiences.Select(ub => ub.Business).Select(ex => ex.Achievements))
                                .Include(o => o.Experiences.Select(ub => ub.Business).Select(ex => ex.BusinessPhones.Select(p => p.Phone)))
                                .Include(o => o.Achievements)
                                .Include(o => o.Educations)
                                .Include(o => o.Skills)
                                .Include(o => o.Languages)
                                .Include(o => o.UserImages
                                    .Select(up => up.Image)
                                ).Where(p => p.UserName == searchText ||
                    p.FirstName == searchText ||
                    p.LastName == searchText ||
                    p.MiddleName == searchText).Skip(from).Take(to - from)
                                .ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return model;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> model = null;

            using (DBContext)
            {
                try
                {
                    model = DBContext.Users
                                .Include(o => o.UserAddresses
                                            .Select(ua => ua.Address)
                                            .Select(ad => ad.TypeCode)
                                            .Select(typ => typ.ClassType)
                                )
                                .Include(o => o.UserAddresses
                                                .Select(ua => ua.Address)
                                                .Select(ad => ad.Country)
                                )
                                .Include(o => o.UserEmails
                                                .Select(ue => ue.Email)
                                                .Select(e => e.TypeCode)
                                                .Select(typ => typ.ClassType)
                                )
                                .Include(o => o.UserPhones
                                                .Select(up => up.Phone)
                                                .Select(p => p.TypeCode)
                                                .Select(typ => typ.ClassType)
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.BusinessAddresses.Select(p => p.Address))
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.BusinessEmails.Select(p => p.Email))
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.BusinessImages.Select(p => p.Image))
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.Achievements)
                                )
                                .Include(o => o.Experiences
                                        .Select(ub => ub.Business)
                                        .Select(ex => ex.BusinessPhones.Select(p => p.Phone))
                                )
                                .Include(o => o.Achievements)
                                .Include(o => o.Educations)
                                .Include(o => o.Skills)
                                .Include(o => o.Languages)
                                .Include(o => o.UserImages
                                    .Select(up => up.Image)
                                )
                                .ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return model;
        }

        public User CreateUser(User model)
        {
            User returnModel = null;
            JobsInABAEntities DBContext = new JobsInABAEntities();
            //using (DBContext)
            //{
            try
            {
                //model.IsActive = false;
                returnModel = DBContext.Users.Add(model);
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //}

            return returnModel;
        }

        public User UpdateUser(User model)
        {
            User returnModel = null;
            if (model != null && model.UserID > 0)
            {
                using (DBContext)
                {
                    User u = DBContext.Users.FirstOrDefault(p => p.UserID == model.UserID);

                    if (u != null)
                    {
                        DBContext.Entry(u).CurrentValues.SetValues(model);
                        DBContext.SaveChanges();
                        returnModel = u;
                    }
                }
            }

            return returnModel;
        }

        public bool DeleteUser(int id)
        {

            Boolean isDeleted = false;
            using (DBContext)
            {
                User u = this.GetUserByID(id);

                if (u != null)
                {
                    DBContext.Users.Remove(u);
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
