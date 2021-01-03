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
    public class TipoDomiciliosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoDomicilios
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoDomicilio.ToListAsync());
        }

        // GET: TipoDomicilios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDomicilio tipoDomicilio = await db.TipoDomicilio.FindAsync(id);
            if (tipoDomicilio == null)
            {
                return HttpNotFound();
            }
            return View(tipoDomicilio);
        }

        // GET: TipoDomicilios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDomicilios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoDomicilio tipoDomicilio)
        {

            List<TipoDomicilio> lstMorador = db.TipoDomicilio.ToList();
            int idEntidade = 0;

            if (lstMorador.Count() <= 0)
            {
                idEntidade = 1;
            }
            else
            {
                idEntidade = lstMorador.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
            }

            tipoDomicilio.Id = idEntidade;


            if (ModelState.IsValid)
            {
                db.TipoDomicilio.Add(tipoDomicilio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoDomicilio);
        }

        // GET: TipoDomicilios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDomicilio tipoDomicilio = await db.TipoDomicilio.FindAsync(id);
            if (tipoDomicilio == null)
            {
                return HttpNotFound();
            }
            return View(tipoDomicilio);
        }

        // POST: TipoDomicilios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoDomicilio tipoDomicilio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDomicilio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoDomicilio);
        }

        // GET: TipoDomicilios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDomicilio tipoDomicilio = await db.TipoDomicilio.FindAsync(id);
            if (tipoDomicilio == null)
            {
                return HttpNotFound();
            }
            return View(tipoDomicilio);
        }

        // POST: TipoDomicilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoDomicilio tipoDomicilio = await db.TipoDomicilio.FindAsync(id);
            db.TipoDomicilio.Remove(tipoDomicilio);
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
