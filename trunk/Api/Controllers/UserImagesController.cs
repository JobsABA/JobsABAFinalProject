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
using JobsInABA.Workflows;

namespace JobsInABA.Web.Api
{
    public class UserImagesController : ApiController
    {
        private UserImagesWorkflows db = new UserImagesWorkflows();

        // GET: api/UserImages
        public IEnumerable<UserImageDTO> GetUserImages()
        {
            return db.Get();
        }

        // GET: api/UserImages/5
        [ResponseType(typeof(UserImageDTO))]
        public IHttpActionResult GetUserImage(int id)
        {
            UserImageDTO userImage = db.Get(id);
            if (userImage == null)
            {
                return NotFound();
            }

            return Ok(userImage);
        }

        // PUT: api/UserImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserImage(int id, UserImageDTO userImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userImage.UserImageID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(userImage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserImageExists(id))
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

        // POST: api/UserImages
        [ResponseType(typeof(UserImageDTO))]
        public IHttpActionResult PostUserImage(UserImageDTO userImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(userImage);

            return CreatedAtRoute("DefaultApi", new { id = userImage.UserImageID }, userImage);
        }

        // DELETE: api/UserImages/5
        [ResponseType(typeof(UserImageDTO))]
        public IHttpActionResult DeleteUserImage(int id)
        {
            UserImageDTO userImage = db.Get(id);
            if (userImage == null)
            {
                return NotFound();
            }

            db.Delete(id);

            return Ok(userImage);
        }

        private bool UserImageExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}