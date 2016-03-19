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
using JobsInABA.DAL.Repositories;

namespace Api.Controllers
{
    public class JobApplicationsController : ApiController
    {
        private JobApplicationsRepo db = new JobApplicationsRepo();

        // GET: api/JobApplications
        public IEnumerable<JobApplication> GetJobApplications()
        {
            return db.GetJobApplications();
        }

        // GET: api/JobApplications/5
        [ResponseType(typeof(JobApplication))]
        public IHttpActionResult GetJobApplication(int id)
        {
            JobApplication jobApplication = db.GetJobApplication(id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return Ok(jobApplication);
        }

        // PUT: api/JobApplications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobApplication(int id, JobApplication jobApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobApplication.JobApplicationID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateJobApplication(id, jobApplication);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplicationExists(id))
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

        // POST: api/JobApplications
        [ResponseType(typeof(JobApplication))]
        public IHttpActionResult PostJobApplication(JobApplication jobApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.CreateJobApplication(jobApplication);

            return CreatedAtRoute("DefaultApi", new { id = jobApplication.JobApplicationID }, jobApplication);
        }

        // DELETE: api/JobApplications/5
        [ResponseType(typeof(JobApplication))]
        public IHttpActionResult DeleteJobApplication(int id)
        {
            JobApplication jobApplication = db.DeleteJobApplication(id);

            return Ok(jobApplication);
        }

        private bool JobApplicationExists(int id)
        {
            return db.GetJobApplication(id) != null;
        }
    }
}