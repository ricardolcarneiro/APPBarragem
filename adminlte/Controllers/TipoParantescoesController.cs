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
    public class TipoParantescoesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoParantescoes
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoParantesco.ToListAsync());
        }

        // GET: TipoParantescoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoParantesco tipoParantesco = await db.TipoParantesco.FindAsync(id);
            if (tipoParantesco == null)
            {
                return HttpNotFound();
            }
            return View(tipoParantesco);
        }

        // GET: TipoParantescoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoParantescoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoParantesco tipoParantesco)
        {
            if (ModelState.IsValid)
            {
                db.TipoParantesco.Add(tipoParantesco);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoParantesco);
        }

        // GET: TipoParantescoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoParantesco tipoParantesco = await db.TipoParantesco.FindAsync(id);
            if (tipoParantesco == null)
            {
                return HttpNotFound();
            }
            return View(tipoParantesco);
        }

        // POST: TipoParantescoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoParantesco tipoParantesco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoParantesco).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoParantesco);
        }

        // GET: TipoParantescoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoParantesco tipoParantesco = await db.TipoParantesco.FindAsync(id);
            if (tipoParantesco == null)
            {
                return HttpNotFound();
            }
            return View(tipoParantesco);
        }

        // POST: TipoParantescoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoParantesco tipoParantesco = await db.TipoParantesco.FindAsync(id);
            db.TipoParantesco.Remove(tipoParantesco);
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
