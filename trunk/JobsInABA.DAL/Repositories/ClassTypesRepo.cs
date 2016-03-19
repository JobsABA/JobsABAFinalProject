using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class ClassTypesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<ClassType> GetClassTypes()
        {
            return db.ClassTypes;
        }

        public ClassType GetClassType(int id)
        {
            ClassType classType = db.ClassTypes.Find(id);
            return classType;
        }

        public void UpdateClassType(int id, ClassType classType)
        {
            db.Entry(classType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public ClassType CreateClassType(ClassType classType)
        {
            db.ClassTypes.Add(classType);
            db.SaveChanges();

            return classType;
        }

        public ClassType DeleteClassType(int id)
        {
            ClassType classType = db.ClassTypes.Find(id);
            if (classType == null)
            {
                return null;
            }

            db.ClassTypes.Remove(classType);
            db.SaveChanges();

            return classType;
        }

        private bool ClassTypeExists(int id)
        {
            return db.ClassTypes.Count(e => e.ClassTypeID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}