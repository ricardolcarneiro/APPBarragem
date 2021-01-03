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
    public class TipoEtinoRacialsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoEtinoRacials
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoEtinoRacial.ToListAsync());
        }

        // GET: TipoEtinoRacials/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEtinoRacial tipoEtinoRacial = await db.TipoEtinoRacial.FindAsync(id);
            if (tipoEtinoRacial == null)
            {
                return HttpNotFound();
            }
            return View(tipoEtinoRacial);
        }

        // GET: TipoEtinoRacials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEtinoRacials/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoEtinoRacial tipoEtinoRacial)
        {
            if (ModelState.IsValid)
            {
                db.TipoEtinoRacial.Add(tipoEtinoRacial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoEtinoRacial);
        }

        // GET: TipoEtinoRacials/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEtinoRacial tipoEtinoRacial = await db.TipoEtinoRacial.FindAsync(id);
            if (tipoEtinoRacial == null)
            {
                return HttpNotFound();
            }
            return View(tipoEtinoRacial);
        }

        // POST: TipoEtinoRacials/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoEtinoRacial tipoEtinoRacial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEtinoRacial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoEtinoRacial);
        }

        // GET: TipoEtinoRacials/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEtinoRacial tipoEtinoRacial = await db.TipoEtinoRacial.FindAsync(id);
            if (tipoEtinoRacial == null)
            {
                return HttpNotFound();
            }
            return View(tipoEtinoRacial);
        }

        // POST: TipoEtinoRacials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoEtinoRacial tipoEtinoRacial = await db.TipoEtinoRacial.FindAsync(id);
            db.TipoEtinoRacial.Remove(tipoEtinoRacial);
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
