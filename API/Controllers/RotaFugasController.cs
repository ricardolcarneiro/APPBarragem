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
using ZeNerd.DAL.Context;

namespace API.Controllers
{
    public class RotaFugasController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/RotaFugas
        public IEnumerable<RotaFuga> GetRotaFuga()
        {
            return db.RotaFuga.ToList();
        }

        // GET: api/RotaFugas/5
        [ResponseType(typeof(RotaFuga))]
        public IHttpActionResult GetRotaFuga(long id)
        {
            RotaFuga RotaFuga = db.RotaFuga.Find(id);
            if (RotaFuga == null)
            {
                return NotFound();
            }

            return Ok(RotaFuga);
        }

        // PUT: api/RotaFugas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRotaFuga(long id, RotaFuga RotaFuga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != RotaFuga.Id)
            {
                return BadRequest();
            }

            db.Entry(RotaFuga).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaFugaExists(id))
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

        // POST: api/RotaFugas
        [ResponseType(typeof(RotaFuga))]
        public IHttpActionResult PostRotaFuga(RotaFuga RotaFuga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RotaFuga.Add(RotaFuga);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RotaFugaExists(RotaFuga.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = RotaFuga.Id }, RotaFuga);
        }

        // DELETE: api/RotaFugas/5
        [ResponseType(typeof(RotaFuga))]
        public IHttpActionResult DeleteRotaFuga(long id)
        {
            RotaFuga RotaFuga = db.RotaFuga.Find(id);
            if (RotaFuga == null)
            {
                return NotFound();
            }

            db.RotaFuga.Remove(RotaFuga);
            db.SaveChanges();

            return Ok(RotaFuga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RotaFugaExists(long id)
        {
            return db.RotaFuga.Count(e => e.Id == id) > 0;
        }
    }
}