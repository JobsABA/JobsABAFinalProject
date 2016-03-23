using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;
using System.Linq;
using System.Collections;

namespace JobsInABA.DAL.Repositories
{
    public class JobsRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Job> GetJobs()
        {
            var job = db.Jobs
                .Include(p => p.JobApplications)
                .Include(o => o.JobApplications)
                .Include(p => p.Business.BusinessUserMaps)
                .Where(x => x.IsDeleted == false)
                .ToList();
            return job;
        }

        public Job GetJob(int id)
        {
            Job job = new Job();
            job = db.Jobs.Where(i => i.JobID == id)
            .Include(p => p.JobApplications)
                .Include(o => o.JobApplications)
                .Include(p => p.Business.BusinessUserMaps)
                .FirstOrDefault();
            return job;
        }

        public void UpdateJob(int id, Job job)
        {
            var mode = db.Jobs.FirstOrDefault(p => p.JobID == id);
            mode = job;
            db.Entry(job).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Job CreateJob(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();

            return job;
        }

        public Job DeleteJob(int id)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return null;
            }

            job.IsDeleted = true;
            job.upddt = DateTime.Now;
            //db.Jobs.Remove(job);
            db.SaveChanges();

            return job;
        }

        private bool JobExists(int id)
        {
            return db.Jobs.Count(e => e.JobID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Job> GetJobsBySearch(string companyName, string jobTitle, string location, int? from, int? to, out int totalJob)
        {
            totalJob = 0;
            var record = db.Jobs
                           .Include(p => p.JobApplications)
                           .Include(o => o.JobApplications)
                           .Include(bus => bus.Business)
                           .Include(p => p.Business.BusinessUserMaps)
                           .Include(busad => busad.Business.BusinessAddresses)
                           .Where(x => x.IsDeleted == false && x.IsActive == true)
                           .ToList();

            if (!string.IsNullOrEmpty(companyName))
            {
                record = record.Where(x => x.Business.Name != null && x.Business.Name.ToLower().Contains(companyName.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(jobTitle))
            {
                record = record.Where(x => x.Title != null && x.Title.ToLower().Contains(jobTitle.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(location))
            {
                record = (from a in record
                          join b in db.BusinessAddresses on a.Business.BusinessID equals b.Business.BusinessID
                          where b.IsPrimary == true && b.Address != null && 
                          (b.Address.City != null && b.Address.City.ToLower().Contains(location.ToLower()) ||
                           b.Address.State != null && b.Address.State.ToLower().Contains(location.ToLower()) ||
                           b.Address.ZipCode != null && b.Address.ZipCode.ToLower().Contains(location.ToLower())
                          )
                          select a).ToList();
            }
            totalJob = record.Count();
            if (from.HasValue && to.HasValue)
            {
                record = record.OrderByDescending(x => x.insdt).Skip(from.Value).Take(to.Value - from.Value).ToList();
            }
            return record;
        }
    }
}