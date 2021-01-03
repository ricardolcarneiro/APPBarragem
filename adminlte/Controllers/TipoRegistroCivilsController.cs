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
    public class TipoRegistroCivilsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoRegistroCivils
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoRegistroCivil.ToListAsync());
        }

        // GET: TipoRegistroCivils/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRegistroCivil tipoRegistroCivil = await db.TipoRegistroCivil.FindAsync(id);
            if (tipoRegistroCivil == null)
            {
                return HttpNotFound();
            }
            return View(tipoRegistroCivil);
        }

        // GET: TipoRegistroCivils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoRegistroCivils/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoRegistroCivil tipoRegistroCivil)
        {
            if (ModelState.IsValid)
            {
                db.TipoRegistroCivil.Add(tipoRegistroCivil);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoRegistroCivil);
        }

        // GET: TipoRegistroCivils/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRegistroCivil tipoRegistroCivil = await db.TipoRegistroCivil.FindAsync(id);
            if (tipoRegistroCivil == null)
            {
                return HttpNotFound();
            }
            return View(tipoRegistroCivil);
        }

        // POST: TipoRegistroCivils/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoRegistroCivil tipoRegistroCivil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoRegistroCivil).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoRegistroCivil);
        }

        // GET: TipoRegistroCivils/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRegistroCivil tipoRegistroCivil = await db.TipoRegistroCivil.FindAsync(id);
            if (tipoRegistroCivil == null)
            {
                return HttpNotFound();
            }
            return View(tipoRegistroCivil);
        }

        // POST: TipoRegistroCivils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoRegistroCivil tipoRegistroCivil = await db.TipoRegistroCivil.FindAsync(id);
            db.TipoRegistroCivil.Remove(tipoRegistroCivil);
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
