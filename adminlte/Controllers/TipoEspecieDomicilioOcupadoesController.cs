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
    public class TipoEspecieDomicilioOcupadoesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoEspecieDomicilioOcupadoes
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoEspecieDomicilioOcupado.ToListAsync());
        }

        // GET: TipoEspecieDomicilioOcupadoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEspecieDomicilioOcupado tipoEspecieDomicilioOcupado = await db.TipoEspecieDomicilioOcupado.FindAsync(id);
            if (tipoEspecieDomicilioOcupado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEspecieDomicilioOcupado);
        }

        // GET: TipoEspecieDomicilioOcupadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEspecieDomicilioOcupadoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoEspecieDomicilioOcupado tipoEspecieDomicilioOcupado)
        {
            if (ModelState.IsValid)
            {
                db.TipoEspecieDomicilioOcupado.Add(tipoEspecieDomicilioOcupado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoEspecieDomicilioOcupado);
        }

        // GET: TipoEspecieDomicilioOcupadoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEspecieDomicilioOcupado tipoEspecieDomicilioOcupado = await db.TipoEspecieDomicilioOcupado.FindAsync(id);
            if (tipoEspecieDomicilioOcupado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEspecieDomicilioOcupado);
        }

        // POST: TipoEspecieDomicilioOcupadoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoEspecieDomicilioOcupado tipoEspecieDomicilioOcupado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEspecieDomicilioOcupado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoEspecieDomicilioOcupado);
        }

        // GET: TipoEspecieDomicilioOcupadoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEspecieDomicilioOcupado tipoEspecieDomicilioOcupado = await db.TipoEspecieDomicilioOcupado.FindAsync(id);
            if (tipoEspecieDomicilioOcupado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEspecieDomicilioOcupado);
        }

        // POST: TipoEspecieDomicilioOcupadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoEspecieDomicilioOcupado tipoEspecieDomicilioOcupado = await db.TipoEspecieDomicilioOcupado.FindAsync(id);
            db.TipoEspecieDomicilioOcupado.Remove(tipoEspecieDomicilioOcupado);
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
