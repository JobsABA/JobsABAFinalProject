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
    public class LanguagesController : ApiController
    {
        private LanguageBL db = new LanguageBL();

        // GET: api/Languages
        public IEnumerable<LanguageDTO> GetLanguages()
        {
            return db.Get();
        }

        public IEnumerable<LanguageDTO> GetLanguagesByUserID(int id)
        {
            return db.Get().Where(p => p.UserID == id);
        }

        // GET: api/Languages/5
        [ResponseType(typeof(LanguageDTO))]
        public IHttpActionResult GetLanguage(int id)
        {
            LanguageDTO language = db.Get(id);
            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        // PUT: api/Languages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLanguage(int id, LanguageDTO language)
        {
            //language = new LanguageDTO();
            //language.LanguageName = "Hindi";
            //language.UserID = 50;
            //language.LanguageID = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != language.LanguageID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(language);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        // POST: api/Languages
        [ResponseType(typeof(LanguageDTO))]
        public IHttpActionResult PostLanguage(LanguageDTO language)
        {
            //language = new LanguageDTO();
            //language.LanguageName = "Kan";
            //language.UserID = 50;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objLang = db.Create(language);

            return CreatedAtRoute("DefaultApi", new { id = language.LanguageID }, objLang);
        }

        // DELETE: api/Languages/5
        
        [ResponseType(typeof(Language))]
        public IHttpActionResult DeleteLanguage(int id)
        {
            LanguageDTO language = db.Get(id);
            if (language == null)
            {
                return NotFound();
            }

            db.Delete(id);

            return Ok(language);
        }

        private bool LanguageExists(int id)
        {
            return db.Get(id) != null;
        }
    }
}