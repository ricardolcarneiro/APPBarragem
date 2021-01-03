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
    public class TipoQuilombolasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoQuilombolas
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoQuilombolas.ToListAsync());
        }

        // GET: TipoQuilombolas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoQuilombolas tipoQuilombolas = await db.TipoQuilombolas.FindAsync(id);
            if (tipoQuilombolas == null)
            {
                return HttpNotFound();
            }
            return View(tipoQuilombolas);
        }

        // GET: TipoQuilombolas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoQuilombolas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoQuilombolas tipoQuilombolas)
        {
            List<TipoQuilombolas> lstEntidade = db.TipoQuilombolas.ToList();
            int idEntidade = 0;

            if (lstEntidade.Count() <= 0)
            {
                idEntidade = 1;
            }
            else
            {
                idEntidade = lstEntidade.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
            }

            tipoQuilombolas.Id = idEntidade;
            if (ModelState.IsValid)
            {
                db.TipoQuilombolas.Add(tipoQuilombolas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoQuilombolas);
        }

        // GET: TipoQuilombolas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoQuilombolas tipoQuilombolas = await db.TipoQuilombolas.FindAsync(id);
            if (tipoQuilombolas == null)
            {
                return HttpNotFound();
            }
            return View(tipoQuilombolas);
        }

        // POST: TipoQuilombolas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoQuilombolas tipoQuilombolas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoQuilombolas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoQuilombolas);
        }

        // GET: TipoQuilombolas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoQuilombolas tipoQuilombolas = await db.TipoQuilombolas.FindAsync(id);
            if (tipoQuilombolas == null)
            {
                return HttpNotFound();
            }
            return View(tipoQuilombolas);
        }

        // POST: TipoQuilombolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoQuilombolas tipoQuilombolas = await db.TipoQuilombolas.FindAsync(id);
            db.TipoQuilombolas.Remove(tipoQuilombolas);
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
