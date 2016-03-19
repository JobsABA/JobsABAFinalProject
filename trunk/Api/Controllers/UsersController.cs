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
using JobsInABA.Workflows;
using JobsInABA.Workflows.Models;

using System.Text;
using JobsInABA.Web.Services;
using JobsInABA.BL.DTOs;
using Api.Services;

namespace Api.Controllers
{
    public class UsersController : ApiController
    {
        private UserWorkflows db = new UserWorkflows();

        // GET: api/Users
        public IEnumerable<UserDataModel> GetUsers()
        {
            return db.Get();
        }

        public List<BusinessDTO> GetUsersWiseCompany(int id)
        {
            return db.GetUsersWiseCompany(id);
        }

        public IEnumerable<UserDataModel> GetUsersBySearch(string searchText, int from, int to)
        {
            if (string.IsNullOrEmpty(searchText))
                return db.Get();
            else
                return db.GetUsersBySearch(searchText, from, to);
        }

        public IEnumerable<UserDataModel> GetUsersByPaging(int from, int to)
        {
            var temp = db.Get().Skip(from).Take(to - from);
            return temp;
        }

        // GET: api/Users/5
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult GetUser(int id)
        {
            UserDataModel user = db.Get().FirstOrDefault(p => p.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, UserDataModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult PostUser([FromBody]UserDataModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lstUser = db.Get();
            bool IsUserNameDuplicate = lstUser.Where(x => x.UserName != null && x.UserName.ToLower() == user.UserName.ToLower()).Count() > 0;
            bool IsEmailExitsDuplicate = lstUser.Where(x => x.UserEmailAddress != null && x.UserEmailAddress.ToLower() == user.UserEmailAddress.ToLower()).Count() > 0;
            bool IsFirstLastDuplicate = lstUser.Where(x => x.FirstName != null && x.FirstName.ToLower() == user.FirstName.ToLower() && x.LastName != null && x.LastName.ToLower() == user.LastName.ToLower()).Count() > 0;

            if (IsUserNameDuplicate)
                return CreatedAtRoute("DefaultApi", new { id = user.UserID }, "Username");
            if (IsEmailExitsDuplicate)
                return CreatedAtRoute("DefaultApi", new { id = user.UserID }, "Email");
            if (IsFirstLastDuplicate)
                return CreatedAtRoute("DefaultApi", new { id = user.UserID }, "FirstLast");

            var objUser = db.Create(user);

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(objUser.UserID.ToString());
            var encodeUserID = System.Convert.ToBase64String(plainTextBytes);
            EmailService.SendRegistrationConfirmMail(user.UserEmailAddress, encodeUserID, user.UserName);
            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, objUser);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok(db.Delete(id));
        }

        private bool UserExists(int id)
        {
            return db.Get(id) != null;
        }

    }
}