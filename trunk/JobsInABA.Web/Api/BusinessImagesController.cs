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
using JobsInABA.BL;
using JobsInABA.BL.DTOs;

namespace Api.Controllers
{
    public class BusinessImagesController : ApiController
    {
        private BusinessImageBL db = new BusinessImageBL();

        // GET: api/BusinessImages
        public IEnumerable<BusinessImageDTO> GetBusinessImages()
        {
            return db.Get();
        }

        // GET: api/BusinessImages/5
        [ResponseType(typeof(BusinessImageDTO))]
        public IHttpActionResult GetBusinessImage(int id)
        {
            BusinessImageDTO businessImage = db.Get(id);
            if (businessImage == null)
            {
                return NotFound();
            }

            return Ok(businessImage);
        }

        // PUT: api/BusinessImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusinessImage(int id, BusinessImageDTO businessImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessImage.BusinessImageID)
            {
                return BadRequest();
            }

            try
            {
                db.Create(businessImage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessImageExists(id))
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

        // POST: api/BusinessImages
        [ResponseType(typeof(BusinessImageDTO))]
        public IHttpActionResult PostBusinessImage(BusinessImageDTO businessImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(businessImage);

            return CreatedAtRoute("DefaultApi", new { id = businessImage.BusinessImageID }, businessImage);
        }

        // DELETE: api/BusinessImages/5
        [ResponseType(typeof(BusinessImageDTO))]
        public IHttpActionResult DeleteBusinessImage(int id)
        {
            BusinessImageDTO businessImage = db.Get(id);
            if (businessImage == null)
            {
                return NotFound();
            }

            db.Create(businessImage);

            return Ok(businessImage);
        }

        private bool BusinessImageExists(int id)
        {
            return db.Get(id)!=null;
        }
    }
}