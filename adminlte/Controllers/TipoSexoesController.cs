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
    public class TipoSexoesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoSexoes
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoSexo.ToListAsync());
        }

        // GET: TipoSexoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSexo tipoSexo = await db.TipoSexo.FindAsync(id);
            if (tipoSexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSexo);
        }

        // GET: TipoSexoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoSexoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoSexo tipoSexo)
        {
            if (ModelState.IsValid)
            {
                db.TipoSexo.Add(tipoSexo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoSexo);
        }

        // GET: TipoSexoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSexo tipoSexo = await db.TipoSexo.FindAsync(id);
            if (tipoSexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSexo);
        }

        // POST: TipoSexoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoSexo tipoSexo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoSexo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoSexo);
        }

        // GET: TipoSexoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSexo tipoSexo = await db.TipoSexo.FindAsync(id);
            if (tipoSexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSexo);
        }

        // POST: TipoSexoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoSexo tipoSexo = await db.TipoSexo.FindAsync(id);
            db.TipoSexo.Remove(tipoSexo);
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
