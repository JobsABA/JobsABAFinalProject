using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JobsInABA.DAL.Entities;
using AutoMapper;

namespace JobsInABA.DAL.Repositories
{
    public class BusinessRepo : IDisposable
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

        public Business GetBusinessByID(Int32 Id)
        {
            Business oBusiness = null;

            //using (DBContext)
            //{
                try
                {
                    oBusiness = DBContext.Businesses.Where(p => p.BusinessID == Id)
                    .Include(o => o.BusinessAddresses
                                        .Select(ua => ua.Address)
                                        .Select(ad => ad.TypeCode)
                                        .Select(typ => typ.ClassType)
                        )
                        .Include(p => p.Achievements)
                        .Include(p => p.Experiences)
                        .Include(p => p.BusinessImages
                                        .Select(k => k.Image))
                        .Include(o => o.BusinessAddresses
                                        .Select(ua => ua.Address)
                                        .Select(ad => ad.Country)
                        )
                        .Include(o => o.BusinessEmails
                                        .Select(ue => ue.Email)
                                        .Select(e => e.TypeCode)
                                        .Select(typ => typ.ClassType)
                        )
                        .Include(o => o.BusinessPhones
                                        .Select(up => up.Phone)
                                        .Select(p => p.TypeCode)
                                        .Select(typ => typ.ClassType)
                        ).Include(o => o.BusinessPhones
                                            .Select(up => up.Phone))
                        .Include(o => o.Experiences)
                        .Include(o => o.Achievements)
                        .Include(o => o.BusinessImages)
                        .Include(o => o.Jobs.Select(p => p.JobApplications))
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            //}

            return oBusiness;
        }

        public IEnumerable<Business> GetBusinesss()
        {
            List<Business> oBusinesss = new List<Business>();

            try
            {
                oBusinesss = DBContext.Businesses
                    .Include(o => o.BusinessAddresses
                                        .Select(ua => ua.Address)
                                        .Select(ad => ad.TypeCode)
                                        .Select(typ => typ.ClassType)
                        )
                        .Include(p => p.Achievements)
                        .Include(p => p.Experiences)
                        .Include(p => p.BusinessImages
                                        .Select(k => k.Image))
                        .Include(o => o.BusinessAddresses
                                        .Select(ua => ua.Address)
                                        .Select(ad => ad.Country)
                        )
                        .Include(o => o.BusinessEmails
                                        .Select(ue => ue.Email)
                                        .Select(e => e.TypeCode)
                                        .Select(typ => typ.ClassType)
                        )
                        .Include(o => o.BusinessPhones
                                        .Select(up => up.Phone)
                                        .Select(p => p.TypeCode)
                                        .Select(typ => typ.ClassType)
                        ).Include(o => o.BusinessPhones.Select(up => up.Phone))
                            .Include(o => o.Experiences)
                            .Include(o => o.Achievements)
                            .Include(o => o.BusinessImages)
                            .Include(o => o.Jobs.Select(p => p.JobApplications))
                            .Include(bser => bser.Services)
                            .ToList();
            }
            catch (Exception ex)
            {
                //Log Exception.
            }

            return oBusinesss;
        }

        public Business CreateBusiness(Business oBusiness)
        {
            Business oBusinessReturn = null;

            using (DBContext)
            {
                try
                {
                    oBusinessReturn = DBContext.Businesses.Add(oBusiness);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oBusinessReturn;
        }

        public Business UpdateBusiness(Business oBusiness)
        {
            Business oBusinessReturn = null;
            if (oBusiness != null && oBusiness.BusinessID > 0)
            {
                //using (DBContext)
                //{
                    Business u = this.GetBusinessByID(oBusiness.BusinessID);

                    if (u != null)
                    {
                        //Mapper.Map<Business, Business>(oBusiness, u);
                        DBContext.SaveChanges();
                        oBusinessReturn = u;
                    }
                //}
            }

            return oBusinessReturn;
        }

        public bool DeleteBusiness(int BusinessID)
        {

            Boolean isDeleted = false;
            using (DBContext)
            {
                Business u = this.GetBusinessByID(BusinessID);

                if (u != null)
                {
                    DBContext.Businesses.Remove(u);
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

        public IEnumerable<Business> GetBusinessesBySearch(string companyname, string city, int? from, int? to, out int totalBusinessCount)
        {
            List<Business> oBusinesss = new List<Business>();
            totalBusinessCount = 0;
            try
            {
                oBusinesss = DBContext.Businesses
                    .Include(o => o.BusinessAddresses
                                        .Select(ua => ua.Address)
                                        .Select(ad => ad.TypeCode)
                                        .Select(typ => typ.ClassType)
                        )
                        .Include(p => p.Achievements)
                        .Include(p => p.Experiences)
                        .Include(p => p.BusinessImages
                                        .Select(k => k.Image))
                        .Include(o => o.BusinessAddresses
                                        .Select(ua => ua.Address)
                                        .Select(ad => ad.Country)
                        )
                        .Include(o => o.BusinessEmails
                                        .Select(ue => ue.Email)
                                        .Select(e => e.TypeCode)
                                        .Select(typ => typ.ClassType)
                        )
                        .Include(o => o.BusinessPhones
                                        .Select(up => up.Phone)
                                        .Select(p => p.TypeCode)
                                        .Select(typ => typ.ClassType)
                        ).Include(o => o.BusinessPhones.Select(up => up.Phone))
                            .Include(o => o.Experiences)
                            .Include(o => o.Achievements)
                            .Include(o => o.BusinessImages)
                            .Include(o => o.Jobs.Select(p => p.JobApplications))
                            .OrderByDescending(x => x.insdt)
                            .ToList();

                if (!string.IsNullOrEmpty(companyname))
                {
                    oBusinesss = oBusinesss.Where(x => x.Name != null && x.Name.ToLower().Contains(companyname.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(city))
                {
                    oBusinesss = (from a in oBusinesss
                                  join b in DBContext.BusinessAddresses on a.BusinessID equals b.Business.BusinessID
                                  where b.IsPrimary == true && b.Address != null && b.Address.City != null && b.Address.City.ToLower().Contains(city.ToLower())
                                  select a).ToList();
                }

                totalBusinessCount = oBusinesss.Count();

                if (from.HasValue && to.HasValue)
                {
                    oBusinesss = oBusinesss.Skip(from.Value).Take(to.Value - from.Value).ToList();
                }
            }
            catch (Exception ex)
            {
                //Log Exception.
            }

            return oBusinesss;
        }

        public List<Business> GetBusinessesNameID()
        {
            List<Business> oBusiness = new List<Business>();
            using (DBContext)
            {
                try
                {
                    oBusiness = DBContext.Businesses.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oBusiness;
        }
    }
}
