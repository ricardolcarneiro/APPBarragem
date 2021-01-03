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
    public class TipoPessoaIndigenasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoPessoaIndigenas
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoPessoaIndigena.ToListAsync());
        }

        // GET: TipoPessoaIndigenas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPessoaIndigena tipoPessoaIndigena = await db.TipoPessoaIndigena.FindAsync(id);
            if (tipoPessoaIndigena == null)
            {
                return HttpNotFound();
            }
            return View(tipoPessoaIndigena);
        }

        // GET: TipoPessoaIndigenas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPessoaIndigenas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoPessoaIndigena tipoPessoaIndigena)
        {
            List<TipoPessoaIndigena> lstEntidade = db.TipoPessoaIndigena.ToList();
            int idEntidade = 0;

            if (lstEntidade.Count() <= 0)
            {
                idEntidade = 1;
            }
            else
            {
                idEntidade = lstEntidade.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
            }

            tipoPessoaIndigena.Id = idEntidade;
            if (ModelState.IsValid)
            {
                db.TipoPessoaIndigena.Add(tipoPessoaIndigena);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoPessoaIndigena);
        }

        // GET: TipoPessoaIndigenas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPessoaIndigena tipoPessoaIndigena = await db.TipoPessoaIndigena.FindAsync(id);
            if (tipoPessoaIndigena == null)
            {
                return HttpNotFound();
            }
            return View(tipoPessoaIndigena);
        }

        // POST: TipoPessoaIndigenas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoPessoaIndigena tipoPessoaIndigena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPessoaIndigena).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoPessoaIndigena);
        }

        // GET: TipoPessoaIndigenas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPessoaIndigena tipoPessoaIndigena = await db.TipoPessoaIndigena.FindAsync(id);
            if (tipoPessoaIndigena == null)
            {
                return HttpNotFound();
            }
            return View(tipoPessoaIndigena);
        }

        // POST: TipoPessoaIndigenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoPessoaIndigena tipoPessoaIndigena = await db.TipoPessoaIndigena.FindAsync(id);
            db.TipoPessoaIndigena.Remove(tipoPessoaIndigena);
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
