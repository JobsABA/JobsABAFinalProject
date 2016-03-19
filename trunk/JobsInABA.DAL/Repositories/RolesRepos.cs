using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class RolesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Role> GetRoles()
        {
            return db.Roles;
        }

        public Role GetRole(int id)
        {
            Role role = db.Roles.Find(id);
            return role;
        }

        public void UpdateRole(int id, Role role)
        {
            var model = db.Roles.FirstOrDefault(p => p.RoleID == id);
            model = role;
            db.Entry(role).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Role CreateRole(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();

            return role;
        }

        public Role DeleteRole(int id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return null;
            }

            db.Roles.Remove(role);
            db.SaveChanges();

            return role;
        }

        private bool RoleExists(int id)
        {
            return db.Roles.Count(e => e.RoleID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}