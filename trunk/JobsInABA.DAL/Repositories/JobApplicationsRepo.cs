using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class JobApplicationsRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<JobApplication> GetJobApplications()
        {
            return db.JobApplications;
        }

        public JobApplication GetJobApplication(int id)
        {
            JobApplication jobApplication = db.JobApplications.Find(id);
            return jobApplication;
        }

        public void UpdateJobApplication(int id, JobApplication jobApplication)
        {
            var model = db.JobApplications.FirstOrDefault(p => p.JobApplicationID == id);
            model = jobApplication;
            db.Entry(jobApplication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public JobApplication CreateJobApplication(JobApplication jobApplication)
        {
            if (db.JobApplications.Count(p => p.JobID == jobApplication.JobID && p.ApplicantUserID == jobApplication.ApplicantUserID) > 0)
                return null;
            jobApplication.ApplicationDate = DateTime.Now;
            db.JobApplications.Add(jobApplication);
            db.SaveChanges();

            return jobApplication;
        }

        public JobApplication DeleteJobApplication(int id)
        {
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return null;
            }

            db.JobApplications.Remove(jobApplication);
            db.SaveChanges();

            return jobApplication;
        }

        private bool JobApplicationExists(int id)
        {
            return db.JobApplications.Count(e => e.JobApplicationID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}