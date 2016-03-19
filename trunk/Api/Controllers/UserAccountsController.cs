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
using System.Text;
using JobsInABA.Workflows.Models;

namespace Api.Controllers
{
    public class UserAccountsController : ApiController
    {
        private UserAccountRepo db = new UserAccountRepo();

        // GET: api/UserAccounts
        public IEnumerable<UserAccount> GetUserAccounts()
        {
            return db.GetUserAccount();
        }

        // GET: api/UserAccounts
        public UserAccount ModifiedPasswordByUserName(SignIn signIn)
        {
            var useraccount =  db.GetUserAccount().FirstOrDefault(p => p.UserName == signIn.Username);
            useraccount.Password = Encoding.ASCII.GetBytes(signIn.Password);
            new UserAccountRepo().UpdateUserAccount(useraccount);
            return useraccount;
        }

        // GET: api/UserAccounts/5
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult GetUserAccount(int id)
        {
            UserAccount userAccount = db.GetUserAccountByID(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return Ok(userAccount);
        }

        // PUT: api/UserAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAccount(int id, UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAccount.UserAccountID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateUserAccount(userAccount);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountExists(id))
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

        // POST: api/UserAccounts
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult PostUserAccount(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateUserAccount(userAccount);

            return CreatedAtRoute("DefaultApi", new { id = userAccount.UserAccountID }, userAccount);
        }

        // DELETE: api/UserAccounts/5
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult DeleteUserAccount(int id)
        {
            var userAccount = db.DeleteUserAccount(id);

            return Ok(userAccount);
        }

        private bool UserAccountExists(int id)
        {
            return db.GetUserAccountByID(id) != null;
        }
    }
}