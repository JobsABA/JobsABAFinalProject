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
    public class ImagesController : ApiController
    {
        private ImageBL db = new ImageBL();

        // GET: api/Images
        public IEnumerable<ImageDTO> GetImages()
        {
            return db.Get();
        }

        // GET: api/Images/5
        [ResponseType(typeof(ImageDTO))]
        public IHttpActionResult GetImage(int id)
        {
            ImageDTO image = db.Get(id);
            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        // PUT: api/Images/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImage(int id, ImageDTO image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.ImageID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(image);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        [ResponseType(typeof(ImageDTO))]
        public IHttpActionResult PostImage(ImageDTO image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(image);

            return CreatedAtRoute("DefaultApi", new { id = image.ImageID }, image);
        }

        // DELETE: api/Images/5
        [ResponseType(typeof(ImageDTO))]
        public IHttpActionResult DeleteImage(int id)
        {
            ImageDTO image = db.Get(id);
            if (image == null)
            {
                return NotFound();
            }

            db.Delete(id);

            return Ok(image);
        }

        private bool ImageExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}