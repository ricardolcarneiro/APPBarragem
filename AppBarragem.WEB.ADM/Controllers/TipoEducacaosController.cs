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
    public class TipoEducacaosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TipoEducacaos
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoEducacao.ToListAsync());
        }

        // GET: TipoEducacaos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEducacao tipoEducacao = await db.TipoEducacao.FindAsync(id);
            if (tipoEducacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoEducacao);
        }

        // GET: TipoEducacaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEducacaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] TipoEducacao tipoEducacao)
        {
            List<TipoEducacao> lstEntidade = db.TipoEducacao.ToList();
            int idEntidade = 0;

            if (lstEntidade.Count() <= 0)
            {
                idEntidade = 1;
            }
            else
            {
                idEntidade = lstEntidade.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
            }

            tipoEducacao.Id = idEntidade;
            if (ModelState.IsValid)
            {
                db.TipoEducacao.Add(tipoEducacao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoEducacao);
        }

        // GET: TipoEducacaos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEducacao tipoEducacao = await db.TipoEducacao.FindAsync(id);
            if (tipoEducacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoEducacao);
        }

        // POST: TipoEducacaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] TipoEducacao tipoEducacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEducacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoEducacao);
        }

        // GET: TipoEducacaos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEducacao tipoEducacao = await db.TipoEducacao.FindAsync(id);
            if (tipoEducacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoEducacao);
        }

        // POST: TipoEducacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoEducacao tipoEducacao = await db.TipoEducacao.FindAsync(id);
            db.TipoEducacao.Remove(tipoEducacao);
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
