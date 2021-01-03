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
    public class RotaDestinoesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/RotaDestinoes
        public IEnumerable<RotaDestino> GetRotaDestino()
        {
            return db.RotaDestino.ToList();
        }

        // GET: api/RotaDestinoes/5
        [ResponseType(typeof(RotaDestino))]
        public IHttpActionResult GetRotaDestino(long id)
        {
            RotaDestino rotaDestino = db.RotaDestino.Find(id);
            if (rotaDestino == null)
            {
                return NotFound();
            }

            return Ok(rotaDestino);
        }

        // PUT: api/RotaDestinoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRotaDestino(long id, RotaDestino rotaDestino)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rotaDestino.Id)
            {
                return BadRequest();
            }

            db.Entry(rotaDestino).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaDestinoExists(id))
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

        // POST: api/RotaDestinoes
        [ResponseType(typeof(RotaDestino))]
        public IHttpActionResult PostRotaDestino(RotaDestino rotaDestino)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RotaDestino.Add(rotaDestino);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RotaDestinoExists(rotaDestino.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rotaDestino.Id }, rotaDestino);
        }

        // DELETE: api/RotaDestinoes/5
        [ResponseType(typeof(RotaDestino))]
        public IHttpActionResult DeleteRotaDestino(long id)
        {
            RotaDestino rotaDestino = db.RotaDestino.Find(id);
            if (rotaDestino == null)
            {
                return NotFound();
            }

            db.RotaDestino.Remove(rotaDestino);
            db.SaveChanges();

            return Ok(rotaDestino);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RotaDestinoExists(long id)
        {
            return db.RotaDestino.Count(e => e.Id == id) > 0;
        }
    }
}