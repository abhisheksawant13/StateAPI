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
using StateApi.Models;

namespace StateApi.Controllers
{
    public class STATE_DATAController : ApiController
    {
        private TestTableEntities db = new TestTableEntities();

        // GET: api/STATE_DATA
        public IQueryable<STATE_DATA> GetSTATE_DATA()
        {
            return db.STATE_DATA;
        }

        // GET: api/STATE_DATA/5
        [ResponseType(typeof(STATE_DATA))]
        public IHttpActionResult GetSTATE_DATA(string id)
        {
            STATE_DATA sTATE_DATA = db.STATE_DATA.Find(id);
            if (sTATE_DATA == null)
            {
                return NotFound();
            }

            return Ok(sTATE_DATA);
        }

        // PUT: api/STATE_DATA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSTATE_DATA(string id, STATE_DATA sTATE_DATA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTATE_DATA.STATE_CODE)
            {
                return BadRequest();
            }

            db.Entry(sTATE_DATA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STATE_DATAExists(id))
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

        // POST: api/STATE_DATA
        [ResponseType(typeof(STATE_DATA))]
        public IHttpActionResult PostSTATE_DATA(STATE_DATA sTATE_DATA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STATE_DATA.Add(sTATE_DATA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STATE_DATAExists(sTATE_DATA.STATE_CODE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sTATE_DATA.STATE_CODE }, sTATE_DATA);
        }

        // DELETE: api/STATE_DATA/5
        [ResponseType(typeof(STATE_DATA))]
        public IHttpActionResult DeleteSTATE_DATA(string id)
        {
            STATE_DATA sTATE_DATA = db.STATE_DATA.Find(id);
            if (sTATE_DATA == null)
            {
                return NotFound();
            }

            db.STATE_DATA.Remove(sTATE_DATA);
            db.SaveChanges();

            return Ok(sTATE_DATA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STATE_DATAExists(string id)
        {
            return db.STATE_DATA.Count(e => e.STATE_CODE == id) > 0;
        }
    }
}