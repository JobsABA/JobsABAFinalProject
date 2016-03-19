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
    public class RolesController : ApiController
    {
        private RolesRepo db = new RolesRepo();

        // GET: api/Roles
        public IEnumerable<Role> GetRoles()
        {
            return db.GetRoles();
        }

        // GET: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult GetRole(int id)
        {
            Role role = db.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.RoleID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateRole(id, role);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateRole(role);

            return CreatedAtRoute("DefaultApi", new { id = role.RoleID }, role);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult DeleteRole(int id)
        {
            Role role = db.DeleteRole(id);

            return Ok(role);
        }

        private bool RoleExists(int id)
        {
            return db.GetRole(id) != null;
        }
    }
}