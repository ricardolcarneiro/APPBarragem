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
    public class RotaFugasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: RotaFugas
        public async Task<ActionResult> Index()
        {
            return View(await db.RotaFuga.ToListAsync());
        }

        // GET: RotaFugas/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RotaFuga RotaFuga = await db.RotaFuga.FindAsync(id);
            if (RotaFuga == null)
            {
                return HttpNotFound();
            }
            return View(RotaFuga);
        }

        // GET: RotaFugas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RotaFugas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Endereco,Latitude,Longitude,Zoom,UsuarioId,Data")] RotaFuga RotaFuga)
        {
            if (ModelState.IsValid)
            {
                db.RotaFuga.Add(RotaFuga);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(RotaFuga);
        }

        // GET: RotaFugas/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RotaFuga RotaFuga = await db.RotaFuga.FindAsync(id);
            if (RotaFuga == null)
            {
                return HttpNotFound();
            }
            return View(RotaFuga);
        }

        // POST: RotaFugas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Endereco,Latitude,Longitude,Zoom,UsuarioId,Data")] RotaFuga RotaFuga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(RotaFuga).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(RotaFuga);
        }

        // GET: RotaFugas/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RotaFuga RotaFuga = await db.RotaFuga.FindAsync(id);
            if (RotaFuga == null)
            {
                return HttpNotFound();
            }
            return View(RotaFuga);
        }

        // POST: RotaFugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            RotaFuga RotaFuga = await db.RotaFuga.FindAsync(id);
            db.RotaFuga.Remove(RotaFuga);
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
