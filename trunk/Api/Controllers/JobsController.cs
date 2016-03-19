using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JobsInABA.DAL.Entities;
using JobsInABA.Workflows;
using JobsInABA.Workflows.Models;
using JobsInABA.BL.DTOs;
using JobsInABA.DAL.Repositories;
using JobsInABA.BL;

namespace Api.Controllers
{
    public class JobsController : ApiController
    {
        private JobWorkflows db = new JobWorkflows();

        // GET: api/Jobs
        public IEnumerable<JobDTO> GetJobs()
        {
            return db.GetJobs();
        }

        public IHttpActionResult GetJobsBySearch(string companyName, string jobTitle, string location, int? from, int? to)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            var jobLst = db.GetJobsBySearch(companyName, jobTitle, location, from, to);
            res["record"] = jobLst;
            res["TotalJobCount"] = jobLst.FirstOrDefault() != null ? jobLst.FirstOrDefault().Count : 0;
            return Ok(res);
        }

        //public IEnumerable<JobDTO> GetJobByPaging(int from, int to)
        //{
        //    return db.GetJobs().OrderBy(p => p.EndDate).Skip(from).Take(to - from);
        //}

        public IEnumerable<JobDTO> GetJobByBusinessID(int id)
        {
            return db.GetJobs().Where(p => p.BusinessID == id);
        }

        // GET: api/Jobs/5
        [ResponseType(typeof(JobDTO))]
        public IHttpActionResult GetJob(int id)
        {
            JobDTO job = db.Get(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/Jobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJob(int id, JobDTO job)
        {
            //job = new JobDTO();
            //job.JobID = id;
            //job.BusinessID = 18;
            //job.Title = "Associate Developer with 1-2 yeAR EXP";
            //job.Description = "Need one Associate software developer";
            //job.JobTypeID = 7;
            //job.IsActive = true;
            //job.IsDeleted = false;
            //job.StartDate = DateTime.Now;
            //job.EndDate = DateTime.Now;
            //job.insuser = 50;
            //job.insdt = DateTime.Now;
            //job.upduser = 50;
            //job.upddt = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.JobID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(job);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Jobs
        [ResponseType(typeof(JobDTO))]
        public IHttpActionResult PostJob(JobDTO job)
        {
            //job = new JobDTO();
            ////job.JobID = 1;
            //job.BusinessID = 18;
            //job.Title = "Associate Developer";
            //job.Description = "Need one Associate software developer";
            //job.JobTypeID = 7;
            //job.IsActive = true;
            //job.IsDeleted = false;
            //job.StartDate = DateTime.Now;
            //job.EndDate = DateTime.Now;
            //job.insuser = 50;
            //job.insdt = DateTime.Now;
            //job.upduser = 50;
            //job.upddt = DateTime.Now;

            ////job.JobApplicationID = 1;
            //job.ApplicantUserID = 1;
            //job.ApplicationDate = DateTime.Now;

            ////job.JobApplicationStateID = 1;
            //job.JobApplicationStatusID = 1;
            //job.JobApplicationinsdt = DateTime.Now;
            //job.JobApplicationinsuser = 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(job);

            return CreatedAtRoute("DefaultApi", new { id = job.JobID }, job);
        }

        // DELETE: api/Jobs/5
        [ResponseType(typeof(JobDTO))]
        public IHttpActionResult DeleteJob(int id)
        {
            return Ok(db.Delete(id));
        }

        private bool JobExists(int id)
        {
            return (db.Get(id) != null);
        }
    }
}