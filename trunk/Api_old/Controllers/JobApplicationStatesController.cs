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
    public class JobApplicationStatesController : ApiController
    {
        private JobApplicationStatesRepo db = new JobApplicationStatesRepo();

        // GET: api/JobApplicationStates
        public IEnumerable<JobApplicationState> GetJobApplicationStates()
        {
            return db.GetJobApplicationStates();
        }

        // GET: api/JobApplicationStates/5
        [ResponseType(typeof(JobApplicationState))]
        public IHttpActionResult GetJobApplicationState(int id)
        {
            JobApplicationState jobApplicationState = db.GetJobApplicationState(id);
            if (jobApplicationState == null)
            {
                return NotFound();
            }

            return Ok(jobApplicationState);
        }

        // PUT: api/JobApplicationStates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobApplicationState(int id, JobApplicationState jobApplicationState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobApplicationState.JobApplicationStateID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateJobApplicationState(id, jobApplicationState);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplicationStateExists(id))
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

        // POST: api/JobApplicationStates
        [ResponseType(typeof(JobApplicationState))]
        public IHttpActionResult PostJobApplicationState(JobApplicationState jobApplicationState)
        {
            //jobApplicationState = new JobApplicationState();
            //jobApplicationState.insuser = 50;
            //jobApplicationState.insdt = DateTime.Now;
            //jobApplicationState.JobApplicationID = 11;
            //jobApplicationState.JobApplicationStatusID = 1;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateJobApplicationState(jobApplicationState);

            return CreatedAtRoute("DefaultApi", new { id = jobApplicationState.JobApplicationStateID }, jobApplicationState);
        }

        // DELETE: api/JobApplicationStates/5
        [ResponseType(typeof(JobApplicationState))]
        public IHttpActionResult DeleteJobApplicationState(int id)
        {
            JobApplicationState jobApplicationState = db.DeleteJobApplicationState(id);

            return Ok(jobApplicationState);
        }

        private bool JobApplicationStateExists(int id)
        {
            return db.GetJobApplicationState(id) != null;
        }
    }
}