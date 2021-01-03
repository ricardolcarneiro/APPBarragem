using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZeNerd.DAL.Context;

namespace adminlte.Controllers
{
    public class RotaDestinoesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: RotaDestinoes
        public async Task<ActionResult> Index()
        {
            return View(await db.RotaDestino.ToListAsync());
        }

        // GET: RotaDestinoes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RotaDestino rotaDestino = await db.RotaDestino.FindAsync(id);
            if (rotaDestino == null)
            {
                return HttpNotFound();
            }
            return View(rotaDestino);
        }

        // GET: RotaDestinoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RotaDestinoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Endereco,Latitude,Longitude,Zoom,UsuarioId,Data")] RotaDestino rotaDestino)
        {
            if (ModelState.IsValid)
            {
                db.RotaDestino.Add(rotaDestino);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rotaDestino);
        }

        // GET: RotaDestinoes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RotaDestino rotaDestino = await db.RotaDestino.FindAsync(id);
            if (rotaDestino == null)
            {
                return HttpNotFound();
            }
            return View(rotaDestino);
        }

        // POST: RotaDestinoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Endereco,Latitude,Longitude,Zoom,UsuarioId,Data")] RotaDestino rotaDestino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rotaDestino).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rotaDestino);
        }

        // GET: RotaDestinoes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RotaDestino rotaDestino = await db.RotaDestino.FindAsync(id);
            if (rotaDestino == null)
            {
                return HttpNotFound();
            }
            return View(rotaDestino);
        }

        // POST: RotaDestinoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            RotaDestino rotaDestino = await db.RotaDestino.FindAsync(id);
            db.RotaDestino.Remove(rotaDestino);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
