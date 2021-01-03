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
    public class GrupoUsuariosController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/GrupoUsuarios
        public IEnumerable<GrupoUsuario> GetGrupoUsuario()
        {
            return db.GrupoUsuario.ToList();
        }

        // GET: api/GrupoUsuarios/5
        [ResponseType(typeof(GrupoUsuario))]
        public IHttpActionResult GetGrupoUsuario(int id)
        {
            GrupoUsuario grupoUsuario = db.GrupoUsuario.Find(id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            return Ok(grupoUsuario);
        }

        // PUT: api/GrupoUsuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrupoUsuario(int id, GrupoUsuario grupoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupoUsuario.Id)
            {
                return BadRequest();
            }

            db.Entry(grupoUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoUsuarioExists(id))
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

        // POST: api/GrupoUsuarios
        [ResponseType(typeof(GrupoUsuario))]
        public IHttpActionResult PostGrupoUsuario(GrupoUsuario grupoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GrupoUsuario.Add(grupoUsuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GrupoUsuarioExists(grupoUsuario.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = grupoUsuario.Id }, grupoUsuario);
        }

        // DELETE: api/GrupoUsuarios/5
        [ResponseType(typeof(GrupoUsuario))]
        public IHttpActionResult DeleteGrupoUsuario(int id)
        {
            GrupoUsuario grupoUsuario = db.GrupoUsuario.Find(id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            db.GrupoUsuario.Remove(grupoUsuario);
            db.SaveChanges();

            return Ok(grupoUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GrupoUsuarioExists(int id)
        {
            return db.GrupoUsuario.Count(e => e.Id == id) > 0;
        }
    }
}