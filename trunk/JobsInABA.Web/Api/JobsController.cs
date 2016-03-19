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
        private JobBL db = new JobBL();

        // GET: api/Jobs
        public IEnumerable<JobDTO> GetJobs()
        {
            return db.Get();
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