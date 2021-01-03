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

namespace AppBarragem.WEB.ADM.Controllers
{
    public class TipoFalaLinguaIndigenasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoFalaLinguaIndigenas
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoFalaLinguaIndigena.ToListAsync());
        }

        // GET: TipoFalaLinguaIndigenas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFalaLinguaIndigena tipoFalaLinguaIndigena = await db.TipoFalaLinguaIndigena.FindAsync(id);
            if (tipoFalaLinguaIndigena == null)
            {
                return HttpNotFound();
            }
            return View(tipoFalaLinguaIndigena);
        }

        // GET: TipoFalaLinguaIndigenas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoFalaLinguaIndigenas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoFalaLinguaIndigena tipoFalaLinguaIndigena)
        {
            List<TipoFalaLinguaIndigena> lstEntidade = db.TipoFalaLinguaIndigena.ToList();
            int idEntidade = 0;

            if (lstEntidade.Count() <= 0)
            {
                idEntidade = 1;
            }
            else
            {
                idEntidade = lstEntidade.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
            }

            tipoFalaLinguaIndigena.Id = idEntidade;
            if (ModelState.IsValid)
            {
                db.TipoFalaLinguaIndigena.Add(tipoFalaLinguaIndigena);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoFalaLinguaIndigena);
        }

        // GET: TipoFalaLinguaIndigenas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFalaLinguaIndigena tipoFalaLinguaIndigena = await db.TipoFalaLinguaIndigena.FindAsync(id);
            if (tipoFalaLinguaIndigena == null)
            {
                return HttpNotFound();
            }
            return View(tipoFalaLinguaIndigena);
        }

        // POST: TipoFalaLinguaIndigenas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoFalaLinguaIndigena tipoFalaLinguaIndigena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoFalaLinguaIndigena).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoFalaLinguaIndigena);
        }

        // GET: TipoFalaLinguaIndigenas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFalaLinguaIndigena tipoFalaLinguaIndigena = await db.TipoFalaLinguaIndigena.FindAsync(id);
            if (tipoFalaLinguaIndigena == null)
            {
                return HttpNotFound();
            }
            return View(tipoFalaLinguaIndigena);
        }

        // POST: TipoFalaLinguaIndigenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoFalaLinguaIndigena tipoFalaLinguaIndigena = await db.TipoFalaLinguaIndigena.FindAsync(id);
            db.TipoFalaLinguaIndigena.Remove(tipoFalaLinguaIndigena);
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
