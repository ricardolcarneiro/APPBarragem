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
    public class GrupoUsuariosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: GrupoUsuarios
        public async Task<ActionResult> Index()
        {
            return View(await db.GrupoUsuario.ToListAsync());
        }

        // GET: GrupoUsuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoUsuario grupoUsuario = await db.GrupoUsuario.FindAsync(id);
            if (grupoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao")] GrupoUsuario grupoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.GrupoUsuario.Add(grupoUsuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoUsuario grupoUsuario = await db.GrupoUsuario.FindAsync(id);
            if (grupoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(grupoUsuario);
        }

        // POST: GrupoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao")] GrupoUsuario grupoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoUsuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoUsuario grupoUsuario = await db.GrupoUsuario.FindAsync(id);
            if (grupoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(grupoUsuario);
        }

        // POST: GrupoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GrupoUsuario grupoUsuario = await db.GrupoUsuario.FindAsync(id);
            db.GrupoUsuario.Remove(grupoUsuario);
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
