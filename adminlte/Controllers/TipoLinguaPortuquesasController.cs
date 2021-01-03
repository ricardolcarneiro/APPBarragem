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
    public class TipoLinguaPortuquesasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoLinguaPortuquesas
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoLinguaPortuquesa.ToListAsync());
        }

        // GET: TipoLinguaPortuquesas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinguaPortuquesa tipoLinguaPortuquesa = await db.TipoLinguaPortuquesa.FindAsync(id);
            if (tipoLinguaPortuquesa == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinguaPortuquesa);
        }

        // GET: TipoLinguaPortuquesas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoLinguaPortuquesas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoLinguaPortuquesa tipoLinguaPortuquesa)
        {
            if (ModelState.IsValid)
            {
                db.TipoLinguaPortuquesa.Add(tipoLinguaPortuquesa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoLinguaPortuquesa);
        }

        // GET: TipoLinguaPortuquesas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinguaPortuquesa tipoLinguaPortuquesa = await db.TipoLinguaPortuquesa.FindAsync(id);
            if (tipoLinguaPortuquesa == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinguaPortuquesa);
        }

        // POST: TipoLinguaPortuquesas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoLinguaPortuquesa tipoLinguaPortuquesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoLinguaPortuquesa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoLinguaPortuquesa);
        }

        // GET: TipoLinguaPortuquesas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinguaPortuquesa tipoLinguaPortuquesa = await db.TipoLinguaPortuquesa.FindAsync(id);
            if (tipoLinguaPortuquesa == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinguaPortuquesa);
        }

        // POST: TipoLinguaPortuquesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoLinguaPortuquesa tipoLinguaPortuquesa = await db.TipoLinguaPortuquesa.FindAsync(id);
            db.TipoLinguaPortuquesa.Remove(tipoLinguaPortuquesa);
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
