using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JobsInABA.DAL.Entities;
using System;

namespace JobsInABA.DAL.Repositories
{
    public class CountriesRepo : IDisposable
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Country> GetCountries()
        {
            return db.Countries.Select(p => p);
        }

        public Country GetCountry(int id)
        {
            Country country = db.Countries.Find(id);
            return country;
        }

        public void UpdateCountry(int id, Country country)
        {
            //var model = db.Countries.FirstOrDefault(p => p.CountryID == id);
            //model = country;
            db.Entry(country).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Country CreateCountry(Country country)
        {
            db.Countries.Add(country);
            db.SaveChanges();

            return country;
        }

        public Country DeleteCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return null;
            }

            db.Countries.Remove(country);
            db.SaveChanges();

            return country;
        }

        private bool CountryExists(int id)
        {
            return db.Countries.Count(e => e.CountryID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}